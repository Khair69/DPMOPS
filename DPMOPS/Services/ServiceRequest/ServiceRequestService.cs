using DPMOPS.Data;
using DPMOPS.Models;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.ServiceRequest
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ServiceRequestDto>> GetAllServiceRequestsAsync()
        {
            var requests = await _context.ServiceRequests
                .Include(r => r.Citizen)
                .Include(r => r.ServiceProvider)
                .Include(r => r.District)
                .Include(r => r.Status)
                .AsNoTracking()
                .ToListAsync();
            IList<ServiceRequestDto> SrDto = new List<ServiceRequestDto>();
            foreach(var request in requests)
            {
                ServiceRequestDto srdto = new ServiceRequestDto();
                srdto.ServiceRequestId = request.ServiceRequestId;
                srdto.LocDescription = request.LocDescription;
                srdto.DateCreated = request.DateCreated;
                srdto.Description = request.Description;
                srdto.Reason = request.Reason;
                srdto.DistrictId = request.DistrictId;
                srdto.Status = request.Status.State;
                srdto.CitizenId = request.CitizenId;
                srdto.ServiceProviderId = request.ServiceProviderId;
                srdto.StatusId = request.StatusId;

                SrDto.Add(srdto);
            }
            return SrDto;
        }

        public Task<ServiceRequestDto> GetServiceRequestByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateServiceRequestAsync(CreateServiceRequestDto srDto)
        {
            var Sr = new Models.ServiceRequest();
            Sr.ServiceRequestId = Guid.NewGuid();
            Sr.LocDescription = srDto.LocDescription;
            Sr.Description = srDto.Description;
            Sr.Reason = srDto.Reason;
            Sr.CitizenId = srDto.CitizenId;
            Sr.ServiceProviderId = srDto.ServiceProviderId;
            Sr.DistrictId = srDto.DistrictId;

            _context.ServiceRequests.Add(Sr);
            var res = await _context.SaveChangesAsync();
            return res == 1;
        }

        public Task<bool> UpdateServiceRequestAsync(UpdateServiceRequestDto srDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteServiceRequestAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ServiceRequestDto>> GetServiceRequestsByCitizenAsync(Guid id)
        {
            var requests = await _context.ServiceRequests
                .Where(r => r.CitizenId == id)
                .Include(r => r.Citizen)
                .Include(r => r.ServiceProvider)
                .Include(r => r.District)
                .Include(r => r.Status)
                .AsNoTracking()
                .ToListAsync();
            IList<ServiceRequestDto> SrDto = new List<ServiceRequestDto>();
            foreach (var request in requests)
            {
                ServiceRequestDto srdto = new ServiceRequestDto();
                srdto.ServiceRequestId = request.ServiceRequestId;
                srdto.LocDescription = request.LocDescription;
                srdto.DateCreated = request.DateCreated;
                srdto.Description = request.Description;
                srdto.Reason = request.Reason;
                srdto.DistrictId = request.DistrictId;
                srdto.Status = request.Status.State;
                srdto.CitizenId = request.CitizenId;
                srdto.ServiceProviderId = request.ServiceProviderId;
                srdto.StatusId = request.StatusId;

                SrDto.Add(srdto);
            }
            return SrDto;
        }
    }
}
