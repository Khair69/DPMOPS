using DPMOPS.Models;
using DPMOPS.Services.Citizen;
using DPMOPS.Services.ServiceProvider;
using DPMOPS.Services.ServiceProvider.Dtos;
using DPMOPS.Services.ServiceType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DPMOPS.Pages.ServiceProvider
{
    [Authorize("IsAdmin")]
    public class AddServiceProviderModel : PageModel
    {
        private readonly ICitizenService _citizenService;
        private readonly IServiceProviderService _serviceProviderService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IServiceTypeService _serviceTypeService;

        public AddServiceProviderModel(ICitizenService citizenService,
            IServiceProviderService serviceProviderService,
            UserManager<ApplicationUser> userManager,
            IServiceTypeService serviceTypeService)
        {
            _citizenService = citizenService;
            _serviceProviderService = serviceProviderService;
            _userManager = userManager;
            _serviceTypeService = serviceTypeService;
        }

        public IEnumerable<SelectListItem> ServiceTypeOptions { get; set; }
        public IEnumerable<SelectListItem> CitizensOptions { get; set; }

        [BindProperty]
        public CreateServiceProviderDto SpDto { get; set; }

        public async Task OnGetAsync()
        {
            ServiceTypeOptions = await _serviceTypeService.GetServiceTypeOptionsAsync();
            CitizensOptions = await _citizenService.GetCitizensOptionsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ServiceTypeOptions = await _serviceTypeService.GetServiceTypeOptionsAsync();
                CitizensOptions = await _citizenService.GetCitizensOptionsAsync();
                return Page();
            }

            var Account = await _userManager.Users
                .Include(u => u.Citizen)
                .FirstOrDefaultAsync(u => u.Id == SpDto.AccountId);
            if (Account == null) return NotFound();

            if (Account.Citizen != null)
            {
                var CitId = Account.Citizen.CitizenId;
                var suc = await _citizenService.DeleteCitizenAsync(CitId);
                if (!suc) return BadRequest();
            }

            var success = await _serviceProviderService.AddServiceProviderAsync(SpDto);
            if (!success) return BadRequest();

            return RedirectToPage("Index");
        }
    }
}
