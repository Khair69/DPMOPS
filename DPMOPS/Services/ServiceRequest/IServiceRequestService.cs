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
        Task<IList<ServiceRequestDto>> GetServiceRequestsByCitizenAsync(string id);
        Task<IList<ServiceRequestDto>> GetServiceRequestsByEmployeeAsync(string id);
        Task<IList<ServiceRequestDto>> GetServiceRequestsByOrganizationAsync(Guid id);
        Task<IList<ServiceRequestDto>> GetUnclaimedRequestsByOrganizationAsync(Guid id);
        Task<bool> ClaimRequestAsync(Guid reqId, string empId);
        Task<bool> ChangeRequestsEmployeeAsync(ChangeEmployeeDto srDto);
    }
}
