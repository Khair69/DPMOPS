#nullable disable
using DPMOPS.Services.City;
using DPMOPS.Services.District;
using DPMOPS.Services.Organization;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsCitizen")]
    [RequestSizeLimit(5_000_000)]
    public class AddModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly ICityService _cityService;
        private readonly IDistrictService _districtService;
        private readonly IOrganizationService _organizationService;

        public AddModel(IServiceRequestService serviceRequestService,
            ICityService cityService,
            IDistrictService districtService,
            IOrganizationService organizationService)
        {
            _serviceRequestService = serviceRequestService;
            _cityService = cityService;
            _districtService = districtService;
            _organizationService = organizationService;
        }

        public IEnumerable<SelectListItem> CityOptions { get; set; }
        public IEnumerable<SelectListItem> DistrictOptions { get; set; }
        public IEnumerable<SelectListItem> OrganizationOptions { get; set; }

        [BindProperty]
        public CreateServiceRequestDto SrDto { get; set; }

        [BindProperty]
        [AllowNull]
        public IFormFile Photo { get; set; }

        public async Task OnGetAsync()
        {
            CityOptions = await _cityService.GetCityOptionsAsync();
            DistrictOptions = Enumerable.Empty<SelectListItem>();
            OrganizationOptions = Enumerable.Empty<SelectListItem>();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CityOptions = await _cityService.GetCityOptionsAsync();
                DistrictOptions = Enumerable.Empty<SelectListItem>();
                OrganizationOptions = Enumerable.Empty<SelectListItem>();
                return Page();
            }

            SrDto.PhotoFile = Photo;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            SrDto.CitizenId = userId;
            
            var successful = await _serviceRequestService.CreateServiceRequestAsync(SrDto);

            if (!successful)
            {
                return BadRequest();
            }

            return RedirectToPage("/Index");
        }

        public async Task<JsonResult> OnGetDistrictsByCity(Guid cityId)
        {
            var districts = await _districtService.GetDistrictOptionsByCityAsync(cityId);
            return new JsonResult(districts);
        }

        public async Task<JsonResult> OnGetOrgsByCity(Guid cityId)
        {
            var orgs = await _organizationService.GetOrganizationOptionsByCityAsync(cityId);
            return new JsonResult(orgs);
        }
    }
}
