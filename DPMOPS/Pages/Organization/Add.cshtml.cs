using DPMOPS.Services.City;
using DPMOPS.Services.City.Dtos;
using DPMOPS.Services.Organization;
using DPMOPS.Services.Organization.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Pages.Organization
{
    [Authorize("IsAdmin")]
    public class AddModel : PageModel
    {
        private readonly IOrganizationService _organizationService;
        private readonly ICityService _cityService;

        public AddModel(IOrganizationService organizationService,
            ICityService cityService)
        {
            _organizationService = organizationService;
            _cityService = cityService;
        }

        [BindProperty]
        public CreateOrganizationDto OrgDto { get; set; }

        public IEnumerable<SelectListItem> CityOptions { get; set; }

        public async Task OnGetAsync()
        {
            CityOptions = await _cityService.GetCityOptionsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var successful = await _organizationService.CreateOrganizationAsync(OrgDto);

            if (!successful)
            {
                return BadRequest();
            }

            return RedirectToPage("Index");
        }
    }
}
