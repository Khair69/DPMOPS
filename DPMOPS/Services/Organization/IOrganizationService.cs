using DPMOPS.Services.Organization.Dtos;

namespace DPMOPS.Services.Organization
{
    public interface IOrganizationService
    {
        Task<IList<OrganizationDto>> GetAllOrganizationsAsync();
        Task<OrganizationDto> GetOrganizationByIdAsync(Guid id);
        Task<bool> CreateOrganizationAsync(CreateOrganizationDto orgDto);
        Task<bool> UpdateOrganizationAsync(UpdateOrganizationDto orgDto);
    }
}
