#nullable disable
using DPMOPS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Pages.Organization.Employees
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authService;

        public IndexModel(UserManager<ApplicationUser> userManager,
            IAuthorizationService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        public List<ApplicationUser> Employees { get; set; }
        public List<ApplicationUser> Admins { get; set; }
        public Guid OrgId { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            AuthorizationResult authResult = await _authService.AuthorizeAsync(User, id, "IsAdminOrOrgAdmin");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }

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

            return Page();
        }
    }
}
