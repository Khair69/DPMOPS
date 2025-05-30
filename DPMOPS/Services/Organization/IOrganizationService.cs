using DPMOPS.Services.Organization.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Services.Organization
{
    public interface IOrganizationService
    {
        Task<IList<OrganizationDto>> GetAllOrganizationsAsync();
        Task<OrganizationDto> GetOrganizationByIdAsync(Guid id);
        Task<bool> CreateOrganizationAsync(CreateOrganizationDto orgDto);
        Task<bool> UpdateOrganizationAsync(UpdateOrganizationDto orgDto);
        Task<IEnumerable<SelectListItem>> GetOrganizationOptionsAsync();
    }
}
