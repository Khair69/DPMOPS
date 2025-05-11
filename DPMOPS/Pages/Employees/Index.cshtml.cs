using DPMOPS.Models;
using DPMOPS.Services.Employee;
using DPMOPS.Services.Employee.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DPMOPS.Pages.Employees
{
    [Authorize("IsProvider")]
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(IEmployeeService employeeService,
            UserManager<ApplicationUser> userManager)
        {
            _employeeService = employeeService;
            _userManager = userManager;
        }

        public IList<EmployeeDto> Employees { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.Users.
                Include(u => u.ServiceProvider)
                .FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid SpId = user.ServiceProvider.ServiceProviderId;
            Employees = await _employeeService.GetAllEmployeesByProviderAsync(SpId);
        }
    }
}
