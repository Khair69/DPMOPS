using DPMOPS.Services.Employee.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Services.Employee
{
    public interface IEmployeeService
    {
        Task<IList<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<bool> AddEmployeeAsync(CreateEmployeeDto EmpDto);
        Task<bool> DeleteEmployeeAsync(Guid id);
        Task<IEnumerable<SelectListItem>> GetEmployeesOptionsAsync();
    }
}
