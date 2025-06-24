#nullable disable

using DPMOPS.Data;
using DPMOPS.Models;
using DPMOPS.Services.Account.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;

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
                    NumberOfRequests = u.CitizinServiceRequests.Count(),
                    OrganizationId = u.OrganizationId
                })
                .AsNoTracking()
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
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<string>> GetAdminIdsInOrg(Guid orgId)
        {
            return await _userManager.Users
                .Where(u => u.OrganizationId == orgId)
                .Where(u => _context.UserClaims
                    .Any(c => c.UserId == u.Id && c.ClaimType == "IsOrgAdmin" && c.ClaimValue == "true"))
                .Select(u => u.Id)
                .AsNoTracking()
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
                .AsNoTracking()
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
                    OrganizationName = u.Organization.Name,
                    OrganizationId = u.OrganizationId
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<AccountDto>> GetOrgAdminsAsync()
        {
            return await _userManager.Users
                .Where(u => _context.UserClaims
                    .Any(c => c.UserId == u.Id && c.ClaimType == "IsOrgAdmin" && c.ClaimValue == "true"))
                .Select(u => new AccountDto
                {
                    AccountId = u.Id,
                    FullName = u.FirstName + " " + u.LastName,
                    Email = u.Email,
                    DateCreated = u.DateCreated,
                    PhoneNumber = u.PhoneNumber,
                    Address = u.District.City.Name + ", " + u.District.Name,
                    OrganizationId = u.OrganizationId
                })
                .AsNoTracking()
                .ToListAsync();
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
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IList<ApplicationUser>> GetAllAdminsAsync()
        {
            var users = _userManager.Users
                .AsNoTracking().ToList();

            IList<ApplicationUser> Admins = new List<ApplicationUser>();
            foreach (var user in users)
            {
                var claims = await _userManager.GetClaimsAsync(user);

                var isAdminClaim = claims.FirstOrDefault(c => c.Type == "IsAdmin");

                if (isAdminClaim != null)
                {
                    Admins.Add(user);
                }
            }
            return Admins;
        }

        public async Task<bool> MakeAdminAsync(string Id)
        {
            var selUser = await _userManager.FindByIdAsync(Id);
            if (selUser == null) return false;

            var claim = new Claim("IsAdmin", "true");
            var res = await _userManager.AddClaimAsync(selUser, claim);
            if (res != null) return true;
            return false;
        }

        public async Task<bool> RemoveAdminAsync(string Id)
        {
            var selUser = await _userManager.FindByIdAsync(Id);
            if (selUser == null) return false;

            var adminClaims = await _userManager.GetClaimsAsync(selUser);
            var isAdminClaims = adminClaims.Where(c => c.Type == "IsAdmin" && c.Value == "true").ToList();

            var res = await _userManager.RemoveClaimsAsync(selUser, isAdminClaims);
            if (res != null) return true;
            return false;
        }

        public async Task<bool> MakeOrgAdminAsync(string Id)
        {
            var selUser = await _userManager.FindByIdAsync(Id);
            if (selUser == null) return false;

            var claim = new Claim("IsOrgAdmin", "true");
            var res = await _userManager.AddClaimAsync(selUser, claim);
            if (res != null) return true;
            return false;
        }

        public async Task<bool> RemoveOrgAdminAsync(string Id)
        {
            var selUser = await _userManager.FindByIdAsync(Id);
            if (selUser == null) return false;

            var adminClaims = await _userManager.GetClaimsAsync(selUser);
            var isAdminClaims = adminClaims.Where(c => c.Type == "IsOrgAdmin" && c.Value == "true").ToList();

            var res = await _userManager.RemoveClaimsAsync(selUser, isAdminClaims);
            if (res != null) return true;
            return false;
        }
    }
}
