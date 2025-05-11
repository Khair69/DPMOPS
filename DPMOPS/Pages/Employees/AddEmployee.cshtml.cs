using DPMOPS.Models;
using DPMOPS.Services.Citizen;
using DPMOPS.Services.Employee;
using DPMOPS.Services.Employee.Dtos;
using DPMOPS.Services.ServiceProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DPMOPS.Pages.Employees
{
    [Authorize("IsProvider")]
    public class AddEmployeeModel : PageModel
    {
        private readonly ICitizenService _citizenService;
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddEmployeeModel(ICitizenService citizenService,
            IEmployeeService employeeService,
            UserManager<ApplicationUser> userManager)
        {
            _citizenService = citizenService;
            _employeeService = employeeService;
            _userManager = userManager;
        }

        public IEnumerable<SelectListItem> CitizensOptions { get; set; }

        [BindProperty]
        public CreateEmployeeDto EmployeeDto { get; set; }

        public async Task OnGetAsync()
        {
            CitizensOptions = await _citizenService.GetCitizensOptionsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CitizensOptions = await _citizenService.GetCitizensOptionsAsync();
                return Page();
            }

            var Account = await _userManager.Users
                .Include(u => u.Citizen)
                .FirstOrDefaultAsync(u => u.Id == EmployeeDto.AccountId);
            if (Account == null) return NotFound();

            if (Account.Citizen != null)
            {
                var CitId = Account.Citizen.CitizenId;
                var suc = await _citizenService.DeleteCitizenAsync(CitId);
                if (!suc) return BadRequest();
            }

            var user = await _userManager.Users.
                Include(u => u.ServiceProvider)
                .FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            EmployeeDto.ServiceProviderId = user.ServiceProvider.ServiceProviderId;

            var success = await _employeeService.AddEmployeeAsync(EmployeeDto);
            if (!success) return BadRequest();

            return RedirectToPage("Index");
        }
    }
}
