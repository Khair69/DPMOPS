using DPMOPS.Services.ServiceRequest.Dtos;

namespace DPMOPS.Services.ServiceRequest
{
    public interface IServiceRequestService
    {
        Task<IList<ServiceRequestDto>> GetAllServiceRequestsAsync();
        Task<ServiceRequestDto> GetServiceRequestByIdAsync(Guid id);
        Task<bool> CreateServiceRequestAsync(CreateServiceRequestDto srDto);
        Task<bool> ChangeRequestStatusAsync(ChangeRequestStatusDto srDto);
        Task<bool> DeleteServiceRequestAsync(Guid id);
        Task<IList<ServiceRequestDto>> GetServiceRequestsByCitizenAsync(Guid id);
        Task<IList<ServiceRequestDto>> GetServiceRequestsByEmployeeAsync(Guid id);
        Task<IList<ServiceRequestDto>> GetServiceRequestsByProviderAsync(Guid id);
    }
}
