using DPMOPS.Models;
using DPMOPS.Services.City;
using DPMOPS.Services.District;
using DPMOPS.Services.EmployeePicker;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using DPMOPS.Services.ServiceType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsCitizen")]
    public class AddRequestModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICityService _cityService;
        private readonly IDistrictService _districtService;
        private readonly IEmployeePicker _employeePicker;
        private readonly IServiceTypeService _serviceTypeService;

        public AddRequestModel(IServiceRequestService serviceRequestService,
            UserManager<ApplicationUser> userManager,
            ICityService cityService,
            IDistrictService districtService,
            IEmployeePicker employeePicker,
            IServiceTypeService serviceTypeService)
        {
            _serviceRequestService = serviceRequestService;
            _userManager = userManager;
            _cityService = cityService;
            _districtService = districtService;
            _employeePicker = employeePicker;
            _serviceTypeService = serviceTypeService;
        }

        public IEnumerable<SelectListItem> CityOptions { get; set; }
        public IEnumerable<SelectListItem> DistrictOptions { get; set; }
        public IEnumerable<SelectListItem> ServiceTypesOptions { get; set; }

        [BindProperty]
        public CreateServiceRequestDto SrDto { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "The service type field is required")]
        public Guid ServiceTypeId { get; set; }

        public async Task OnGetAsync()
        {
            CityOptions = await _cityService.GetCityOptionsAsync();
            DistrictOptions = Enumerable.Empty<SelectListItem>();
            ServiceTypesOptions = await _serviceTypeService.GetServiceTypeOptionsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CityOptions = await _cityService.GetCityOptionsAsync();
                DistrictOptions = Enumerable.Empty<SelectListItem>();
                ServiceTypesOptions = await _serviceTypeService.GetServiceTypeOptionsAsync();
                return Page();
            }

            var user = await _userManager.Users.
                Include(u => u.Citizen)
                .FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            SrDto.CitizenId = user.Citizen.CitizenId;

            var CityId = await _districtService.GetCityIdByDistrictAsync((Guid)SrDto.DistrictId);

            SrDto.EmployeeId = await _employeePicker.PickAsync(ServiceTypeId,CityId);
            
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
    }
}
