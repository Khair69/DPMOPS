using DPMOPS.Enums;
using DPMOPS.Services.UserClaim;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserClaimService _userClaimService;

        public IndexModel(IUserClaimService userClaimService)
        {
            _userClaimService = userClaimService;
        }

        public IActionResult OnGet()
        {
            var userType = _userClaimService.ResolveUserType(User);

            return userType switch
            {
                UserType.Admin => RedirectToPage("/Analytics/Index"),
                UserType.Employee => RedirectToPage("/ServiceRequest/ByEmp"),
                UserType.OrgAdmin => RedirectToPage("/Analytics/Index"),
                UserType.Citizen => RedirectToPage("/ServiceRequest/ByCitizen"),
                _ => Page()
            };
        }
    }
}
