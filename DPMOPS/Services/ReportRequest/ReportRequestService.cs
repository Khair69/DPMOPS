using DPMOPS.Data;
using DPMOPS.Models;
using DPMOPS.Services.ReportRequest.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.ReportRequest
{
    public class ReportRequestService : IReportRequestService
    {
        private readonly ApplicationDbContext _context;

        public ReportRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ReportRequestDto>> GetAllReportRequestsAsync()
        {
            var requests = await _context.ReportRequests
                .Include(r => r.Citizen)
                .ThenInclude(r => r.Account)
                .Include(r => r.ServiceProvider)
                    .ThenInclude(sp => sp.Account)
                .Include(r => r.ServiceProvider)
                    .ThenInclude(sp => sp.ServiceType)
                .Include(r => r.District)
                .ThenInclude(r => r.City)
                .AsNoTracking()
                .ToListAsync();
            IList<ReportRequestDto> RrDto = new List<ReportRequestDto>();
            foreach (var request in requests)
            {
                ReportRequestDto rrdto = new ReportRequestDto();
                rrdto.ReportRequestId = request.ReportRequestId;
                rrdto.LocDescription = request.LocDescription;
                rrdto.DateCreated = request.DateCreated;
                rrdto.Description = request.Description;
                rrdto.Reason = request.Reason;
                rrdto.DistrictId = request.DistrictId;
                rrdto.Address = (request.District.City.Name + ", " + request.District.Name);
                rrdto.Status = (Status)request.StatusId;
                rrdto.CitizenId = request.CitizenId;
                rrdto.CitizenName = (request.Citizen.Account.FirstName + " " + request.Citizen.Account.LastName);
                rrdto.ServiceProviderId = request.ServiceProviderId;
                rrdto.ProviderName = (request.ServiceProvider.Account.FirstName + " " + request.ServiceProvider.Account.LastName);
                rrdto.ServiceType = request.ServiceProvider.ServiceType.Name;

                RrDto.Add(rrdto);
            }
            return RrDto;
        }

        public Task<ReportRequestDto> GetReportRequestByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateReportRequestAsync(CreateReportRequestDto rrDto)
        {
            var Rr = new Models.ReportRequest();
            Rr.ReportRequestId = Guid.NewGuid();
            Rr.LocDescription = rrDto.LocDescription;
            Rr.Description = rrDto.Description;
            Rr.Reason = rrDto.Reason;
            Rr.CitizenId = rrDto.CitizenId;
            Rr.ServiceProviderId = rrDto.ServiceProviderId;
            Rr.DistrictId = rrDto.DistrictId;

            _context.ReportRequests.Add(Rr);
            var res = await _context.SaveChangesAsync();
            return res == 1;
        }

        public Task<bool> UpdateReportRequestAsync(UpdateReportRequestDto srDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteReportRequestAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
