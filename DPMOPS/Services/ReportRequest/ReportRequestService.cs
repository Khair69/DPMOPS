using DPMOPS.Data;
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
                .Include(r => r.ServiceProvider)
                .Include(r => r.District)
                .Include(r => r.Status)
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
                rrdto.Status = request.Status.State;
                rrdto.CitizenId = request.CitizenId;
                rrdto.ServiceProviderId = request.ServiceProviderId;
                rrdto.StatusId = request.StatusId;

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
