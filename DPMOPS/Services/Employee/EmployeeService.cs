using DPMOPS.Data;
using DPMOPS.Models;
using DPMOPS.Services.Employee.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace DPMOPS.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeService(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IList<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees
                .Include(e => e.Account)
                    .ThenInclude(a => a.District)
                        .ThenInclude(c => c.City)
                .Include(e => e.ServiceProvider)
                    .ThenInclude(sp => sp.ServiceType)
                 .Include(e => e.ServiceProvider)
                    .ThenInclude(sp => sp.Account)
                .Include(e => e.ServiceRequests)
                .AsNoTracking()
                .ToListAsync();

            IList<EmployeeDto> EmpDto = new List<EmployeeDto>();
            foreach (var employee in employees) 
            {
                EmployeeDto employeeDto = new EmployeeDto();
                employeeDto.EmployeeId = employee.EmployeeId;
                employeeDto.AccountId = employee.AccountId;
                employeeDto.EmployeeName = (employee.Account.FirstName + " " + employee.Account.LastName);
                employeeDto.ServiceProviderId = employee.ServiceProviderId;
                employeeDto.ProviderName = employee.ServiceProvider.Account.FirstName;
                employeeDto.ServiceTypeId = employee.ServiceProvider.ServiceTypeId;
                employeeDto.ServiceType = employee.ServiceProvider.ServiceType.Name;
                employeeDto.EmployeeEmail = employee.Account.Email;
                employeeDto.DistrictId = employee.Account.DistrictId;
                employeeDto.Address = (employee.Account.District.City.Name + ", " + employee.Account.District.Name);
                employeeDto.DateOfBirth = employee.Account.DateOfBirth;
                employeeDto.NumberOfServiceRequests = employee.ServiceRequests.Count();
                EmpDto.Add(employeeDto);
            }
            return EmpDto;
        }

        public Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddEmployeeAsync(CreateEmployeeDto EmpDto)
        {
            var employee = new Models.Employee();
            employee.EmployeeId = Guid.NewGuid();
            employee.AccountId = EmpDto.AccountId;
            employee.ServiceProviderId = EmpDto.ServiceProviderId;

            _context.Employees.Add(employee);
            var res = await _context.SaveChangesAsync();

            if (res == 1)
            {
                var selUser = await _userManager.FindByIdAsync(EmpDto.AccountId);
                if (selUser == null) return false;
                var claim = new Claim("IsEmployee", "true");
                var result = await _userManager.AddClaimAsync(selUser, claim);
                if (result != null) return true;
                return false;
            }

            return res == 1;
        }

        public Task<bool> DeleteEmployeeAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SelectListItem>> GetEmployeesOptionsAsync()
        {
            return await _context.Employees
                .Include(e => e.Account)
                .Select(e => new SelectListItem
                {
                    Value = e.EmployeeId.ToString(),
                    Text = (e.Account.FirstName +" "+e.Account.LastName)
                })
                .ToListAsync();
        }
    }
}
