#nullable disable

using DPMOPS.Data;
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
        private readonly ApplicationDbContext _context;

        public AccountService(UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
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
                .Where(u => !_context.UserClaims
                    .Any(c => c.UserId == u.Id && c.ClaimType == "IsAdmin" && c.ClaimValue == "true"))
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

        public async Task<IList<string>> GetAdminIdsInOrg(Guid orgId)
        {
            return await _userManager.Users
                .Where(u => u.OrganizationId == orgId)
                .Where(u => _context.UserClaims
                    .Any(c => c.UserId == u.Id && c.ClaimType == "IsOrgAdmin" && c.ClaimValue == "true"))
                .Select(u => u.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetEmployeesInOrgOptionsAsync(Guid orgId)
        {
            return await _userManager.Users
                .Where(u => u.OrganizationId == orgId)
                .Where(u => !_context.UserClaims
                    .Any(c => c.UserId == u.Id && c.ClaimType == "IsOrgAdmin" && c.ClaimValue == "true"))
                .Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.FirstName + " " + u.LastName,
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

        public Task<IList<AccountDto>> GetOrgAdminsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserHasClaimAsync(string userId, string claimType, string claimValue)
        {
            return await _context.UserClaims
                .AnyAsync(c => c.UserId == userId && c.ClaimType == claimType && c.ClaimValue == claimValue);
        }

        public async Task<string> ValueOfUserClaimAsync(string userId, string claimType)
        {
            return await _context.UserClaims
                .Where(c => c.UserId == userId && c.ClaimType == claimType)
                .Select (c => c.ClaimValue)
                .FirstOrDefaultAsync();
        }
    }
}
