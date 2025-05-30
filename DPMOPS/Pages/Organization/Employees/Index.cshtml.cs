using DPMOPS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Pages.Organization.Employees
{
    //Auth is in this org
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public List<ApplicationUser> Employees { get; set; }
        public List<ApplicationUser> Admins { get; set; }
        public Guid OrgId { get; set; }

        public async Task OnGetAsync(Guid id)
        {
            OrgId = id;
            var users = await _userManager.Users
                .Where(u => u.OrganizationId == id)
                .Include(u => u.District)
                    .ThenInclude(u => u.City)
                .ToListAsync();
            Employees = new List<ApplicationUser>();
            Admins = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var claims = await _userManager.GetClaimsAsync(user);

                var isAdminClaim = claims.FirstOrDefault(c => c.Type == "IsOrgAdmin");
                if (isAdminClaim != null)
                {
                    Admins.Add(user);
                }
                else
                {
                    Employees.Add(user);
                }
            }
        }
    }
}
