using DPMOPS.Services.ServiceType.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Services.ServiceType
{
    public interface IServiceTypeService
    {
        Task<IList<ServiceTypeDto>> GetAllServiceTypesAsync();
        Task<ServiceTypeDto> GetServiceTypeByIdAsync(Guid id);
        Task<bool> CreateServiceTypeAsync(CreateServiceTypeDto stDto);
        Task<bool> UpdateServiceTypeAsync(UpdateServiceTypeDto stDto);
        Task<bool> DeleteServiceTypeAsync(Guid id);
        Task<IEnumerable<SelectListItem>> GetServiceTypeOptionsAsync();
    }
}
