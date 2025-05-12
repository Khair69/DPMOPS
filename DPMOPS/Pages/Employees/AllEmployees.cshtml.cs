using DPMOPS.Models;
using DPMOPS.Services.Employee.Dtos;
using DPMOPS.Services.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Pages.Employees
{
    [Authorize("IsAdmin")]
    public class AllEmployeesModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public AllEmployeesModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IList<EmployeeDto> Employees { get; set; }

        public async Task OnGetAsync()
        {
            Employees = await _employeeService.GetAllEmployeesAsync();
        }
    }
}
