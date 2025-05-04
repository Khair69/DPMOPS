using DPMOPS.Models;
using DPMOPS.Services.City;
using DPMOPS.Services.City.Dtos;
using DPMOPS.Services.District;
using DPMOPS.Services.ServiceProvider;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsCitizen")]
    public class AddServiceRequestModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICityService _cityService;
        private readonly IDistrictService _districtService;
        private readonly IServiceProviderService _serviceProviderService;

        public AddServiceRequestModel(IServiceRequestService serviceRequestService,
            UserManager<ApplicationUser> userManager,
            ICityService cityService,
            IDistrictService districtService,
            IServiceProviderService serviceProviderService)
        {
            _serviceRequestService = serviceRequestService;
            _userManager = userManager;
            _cityService = cityService;
            _districtService = districtService;
            _serviceProviderService = serviceProviderService;
        }

        public IEnumerable<SelectListItem> CityOptions { get; set; }
        public IEnumerable<SelectListItem> DistrictOptions { get; set; }
        public IEnumerable<SelectListItem> ServiceProviderOptions { get; set; }

        [BindProperty]
        public CreateServiceRequestDto SrDto { get; set; }

        public async Task OnGetAsync()
        {
            CityOptions = await _cityService.GetCityOptionsAsync();
            DistrictOptions = Enumerable.Empty<SelectListItem>();
            ServiceProviderOptions = await _serviceProviderService.GetServiceProvidersOptionsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CityOptions = await _cityService.GetCityOptionsAsync();
                DistrictOptions = Enumerable.Empty<SelectListItem>();
                ServiceProviderOptions = await _serviceProviderService.GetServiceProvidersOptionsAsync();
                return Page();
            }

            var user = await _userManager.Users.
                Include(u => u.Citizen)
                .FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            SrDto.CitizenId = user.Citizen.CitizenId;
            Console.WriteLine(SrDto.CitizenId);
            
            var successful = await _serviceRequestService.CreateServiceRequestAsync(SrDto);

            if (!successful)
            {
                return BadRequest();
            }

            return RedirectToPage("Index");
        }

        public async Task<JsonResult> OnGetDistrictsByCity(Guid cityId)
        {
            var districts = await _districtService.GetDistrictOptionsByCityAsync(cityId);
            return new JsonResult(districts);
        }
    }
}
