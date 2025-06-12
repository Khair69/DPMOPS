#nullable disable
using DPMOPS.Models;
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
            var users = await _userManager.Users
                .Include(u => u.District)
                    .ThenInclude(u => u.City)
                .ToListAsync();
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
