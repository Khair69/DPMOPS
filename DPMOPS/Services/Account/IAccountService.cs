using DPMOPS.Models;
using DPMOPS.Services.Account.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Services.Account
{
    public interface IAccountService
    {
        Task<IList<AccountDto>> GetCitizensAsync();
        Task<IList<AccountDto>> GetEmployeesAsync();
        Task<IList<AccountDto>> GetOrgAdminsAsync();
        Task<IList<ApplicationUser>> GetAllAdminsAsync();
        Task<AccountDto> GetAccountByIdAsync(string id);
        Task<IEnumerable<SelectListItem>> GetEmployeesInOrgOptionsAsync(Guid orgId);
        Task<IList<string>> GetAdminIdsInOrg(Guid orgId);
        Task<bool> UserHasClaimAsync(string userId, string claimType, string claimValue);
        Task<string> ValueOfUserClaimAsync(string userId, string claimType);
        Task<bool> MakeAdminAsync(string Id);
        Task<bool> RemoveAdminAsync(string Id);
        Task<bool> MakeOrgAdminAsync(string Id);
        Task<bool> RemoveOrgAdminAsync(string Id);
    }
}
