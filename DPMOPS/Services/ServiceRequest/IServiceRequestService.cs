using DPMOPS.Services.ServiceRequest.Dtos;

namespace DPMOPS.Services.ServiceRequest
{
    public interface IServiceRequestService
    {
        Task<IList<ServiceRequestDto>> GetAllServiceRequestsAsync();
        Task<ServiceRequestDto> GetServiceRequestByIdAsync(Guid id);
        Task<bool> CreateServiceRequestAsync(CreateServiceRequestDto srDto);
        Task<bool> UpdateServiceRequestAsync(UpdateServiceRequestDto srDto);
        Task<bool> DeleteServiceRequestAsync(Guid id);
    }
}
