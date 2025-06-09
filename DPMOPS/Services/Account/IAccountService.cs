using DPMOPS.Services.Account.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Services.Account
{
    public interface IAccountService
    {
        Task<IList<AccountDto>> GetCitizensAsync();
        Task<IList<AccountDto>> GetEmployeesAsync();
        Task<IEnumerable<SelectListItem>> GetEmployeeInOrgOptionsAsync(Guid orgId);
        Task<IList<string>> GetEmpIdInOrg(Guid orgId);
    }
}
