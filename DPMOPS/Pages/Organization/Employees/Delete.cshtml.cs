using DPMOPS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Organization.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IAuthorizationService _authService;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteModel(IAuthorizationService authService,
            UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            string? claim = User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value;
            Guid orgId = Guid.Empty;
            if (claim != null)
            {
                orgId = Guid.Parse(claim);
            }
            AuthorizationResult authResult = await _authService.AuthorizeAsync(User, orgId, "IsAdminOrOrgAdmin");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            Guid? OrgClaim = user.OrganizationId;

            var succesful = await _userManager.DeleteAsync(user);
            if (!succesful.Succeeded)
            {
                return BadRequest();
            }

            return RedirectToPage("Index", new { id = OrgClaim });

        }
    }
}
