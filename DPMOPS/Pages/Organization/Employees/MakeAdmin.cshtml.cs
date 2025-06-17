using DPMOPS.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Organization.Employees
{
    public class MakeAdminModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IAuthorizationService _authService;

        public MakeAdminModel(IAccountService accountService,
            IAuthorizationService authorizationService)
        {
            _accountService = accountService;
            _authService = authorizationService;
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
            //should check if not allready admin
            var succesful = await _accountService.MakeOrgAdminAsync(id);
            if (!succesful)
            {
                return BadRequest();
            }

            var OrgClaim = await _accountService.ValueOfUserClaimAsync(id, "OrganizationId");

            return RedirectToPage("Index", new { id = Guid.Parse(OrgClaim) });
        }
    }
}
