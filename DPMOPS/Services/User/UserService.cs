using Microsoft.AspNetCore.Identity;
using DPMOPS.Models;
using System.Security.Claims;

namespace DPMOPS.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IList<ApplicationUser>> GetAllAdminsAsync()
        {
            var users = _userManager.Users.ToList();

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
    }
}
