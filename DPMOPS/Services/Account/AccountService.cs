#nullable disable

using DPMOPS.Models;
using DPMOPS.Services.Account.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AccountDto> GetAccountByIdAsync(string id)
        {
            return await _userManager.Users
                .Where(u => u.Id == id)
                .Include(u => u.District)
                    .ThenInclude(d => d.City)
                .Include(u => u.CitizinServiceRequests)
                .Select(u => new AccountDto
                {
                    AccountId = u.Id,
                    FullName = u.FirstName + " " + u.LastName,
                    Email = u.Email,
                    DateCreated = u.DateCreated,
                    PhoneNumber = u.PhoneNumber,
                    Address = u.District.City.Name + ", " + u.District.Name,
                    NumberOfRequests = u.CitizinServiceRequests.Count()
                })
                .FirstOrDefaultAsync();

        }

        public async Task<IList<AccountDto>> GetCitizensAsync()
        {
            return await _userManager.Users
                .Where(u => u.OrganizationId == null)
                .Include(u => u.District)
                    .ThenInclude(d => d.City)
                .Include(u => u.CitizinServiceRequests)
                .Select(u => new AccountDto
                {
                    AccountId = u.Id,
                    FullName = u.FirstName + " " + u.LastName,
                    Email = u.Email,
                    DateCreated = u.DateCreated,
                    PhoneNumber = u.PhoneNumber,
                    Address = u.District.City.Name + ", " + u.District.Name,
                    NumberOfRequests = u.CitizinServiceRequests.Count()
                })
                .ToListAsync();
        }

        public async Task<IList<string>> GetEmpIdInOrg(Guid orgId)
        {
            return await _userManager.Users
                .Where(u => u.OrganizationId == orgId)
                .Select(u => u.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetEmployeeInOrgOptionsAsync(Guid orgId)
        {
            return await _userManager.Users
                .Where(u => u.OrganizationId == orgId)
                .Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.FirstName +" "+u.LastName,
                })
                .ToListAsync();
        }

        public async Task<IList<AccountDto>> GetEmployeesAsync()
        {
            return await _userManager.Users
                .Where(u => u.OrganizationId != null)
                .Include(u => u.District)
                    .ThenInclude(d => d.City)
                .Include(u => u.EmployeeServiceRequests)
                .Include(u => u.Organization)
                .Select(u => new AccountDto
                {
                    AccountId = u.Id,
                    FullName = u.FirstName + " " + u.LastName,
                    Email = u.Email,
                    DateCreated = u.DateCreated,
                    PhoneNumber = u.PhoneNumber,
                    Address = u.District.City.Name + ", " + u.District.Name,
                    NumberOfRequests = u.EmployeeServiceRequests.Count(),
                    OrganizationName = u.Organization.Name
                })
                .ToListAsync();
        }
    }
}
