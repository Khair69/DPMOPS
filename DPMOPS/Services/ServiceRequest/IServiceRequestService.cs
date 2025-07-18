﻿using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Services.ServiceRequest
{
    public interface IServiceRequestService
    {
        Task<IList<ServiceRequestDto>> GetAllServiceRequestsAsync();
        Task<ServiceRequestDto> GetServiceRequestByIdAsync(Guid id);
        Task<bool> CreateServiceRequestAsync(CreateServiceRequestDto srDto);
        Task<bool> DeleteServiceRequestAsync(Guid id);
        Task<IList<ServiceRequestDto>> GetServiceRequestsByCitizenAsync(string id);
        Task<IList<ServiceRequestDto>> GetServiceRequestsByEmployeeAsync(string id);
        Task<IList<ServiceRequestDto>> GetServiceRequestsByOrganizationAsync(Guid id);
        Task<bool> ChangeRequestStatusAsync(ChangeRequestStatusDto srDto);
        Task<bool> AssignEmployeeAsync(AssignEmployeeDto srDto);
        Task<bool> ChangeEmployeeAsync(AssignEmployeeDto srDto);
        Task<IList<ServiceRequestDto>> GetAllPublicServiceRequestsAsync(Guid? cityId = null);
        Task<bool> ReviewServiceRequest(ReviewDto reDto);
        Task<IEnumerable<SelectListItem>> GetCitizenRequestsOptions(string citId);
    }
}
