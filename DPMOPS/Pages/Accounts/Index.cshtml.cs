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
        private readonly IDistrictService _districtService;

        public IndexModel(UserManager<ApplicationUser> userManager, IDistrictService districtService)
        {
            _userManager = userManager;
            _districtService = districtService;
        }

        public List<(ApplicationUser user, string location, string type)> Users { get; set; }
        public List<(ApplicationUser user, string location)> Admins{ get; set; }

        public async Task OnGetAsync()
        {
            var users = _userManager.Users.Include(u => u.Citizen).Include(u => u.ServiceProvider).ToList();
            Users = new List<(ApplicationUser, string, string)>();
            Admins = new List<(ApplicationUser, string)>();

            foreach (var user in users)
            {
                var district = await _districtService.GetDistrictByIdAsync(user.DistrictId);
                string loc = district.CityName + ", " + district.Name;
                var claims = await _userManager.GetClaimsAsync(user);
                string typ;
                if (user.Citizen != null)
                {
                    typ = "Citizen";
                }
                else if (user.ServiceProvider != null)
                {
                    typ = "Service Provider";
                }
                else
                {
                    typ = "None";
                }

                var isAdminClaim = claims.FirstOrDefault(c => c.Type == "IsAdmin");
                if (isAdminClaim != null)
                {
                    Admins.Add((user, loc));
                }
                else
                {
                    Users.Add((user, loc, typ));
                }
            }
        }
    }
}
