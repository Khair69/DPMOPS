using DPMOPS.Models;
using DPMOPS.Services.District;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Pages.Accounts
{
    [Authorize("IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public List<ApplicationUser> Users { get; set; }
        public List<ApplicationUser> Admins{ get; set; }

        public async Task OnGetAsync()
        {
            var users = _userManager.Users
                .Include(u => u.Citizen)
                .Include(u => u.ServiceProvider)
                .Include(u => u.Employee)
                .Include(u => u.District)
                    .ThenInclude(u => u.City)
                .ToList();
            Users = new List<ApplicationUser>();
            Admins = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var claims = await _userManager.GetClaimsAsync(user);

                var isAdminClaim = claims.FirstOrDefault(c => c.Type == "IsAdmin");
                if (isAdminClaim != null)
                {
                    Admins.Add(user);
                }
                else
                {
                    Users.Add(user);
                }
            }
        }
    }
}
