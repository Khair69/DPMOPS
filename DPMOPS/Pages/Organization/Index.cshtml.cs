#nullable disable
using DPMOPS.Services.Organization;
using DPMOPS.Services.Organization.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Organization
{
    [Authorize("IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IOrganizationService _organizationService;

        public IndexModel(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public IList<OrganizationDto> Organizations { get; set; }

        public async Task OnGetAsync()
        {
            Organizations = await _organizationService.GetAllOrganizationsAsync();
        }
    }
}
