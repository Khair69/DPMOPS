#nullable disable
using DPMOPS.Services.Organization;
using DPMOPS.Services.Organization.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Organization
{
    [Authorize("IsAdmin")]
    public class EditModel : PageModel
    {
        private readonly IOrganizationService _organizationService;

        public EditModel(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public OrganizationDto OrgDto { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            OrgDto = await _organizationService.GetOrganizationByIdAsync(id);
            if (OrgDto == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public UpdateOrganizationDto OrgUpdateDto { get; set; }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            OrgUpdateDto.OrganizationId = id;
            var successful = await _organizationService.UpdateOrganizationAsync(OrgUpdateDto);

            if (!successful)
            {
                return BadRequest();
            }

            return RedirectToPage("Index");
        }
    }
}
