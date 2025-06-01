using DPMOPS.Services.ServiceRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsEmployee")]
    public class ClaimModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IAuthorizationService _authService;

        public ClaimModel(IServiceRequestService serviceRequestService,
            IAuthorizationService authService)
        {
            _serviceRequestService = serviceRequestService;
            _authService = authService;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var req = await _serviceRequestService.GetServiceRequestByIdAsync(id);

            AuthorizationResult authResult = await _authService.AuthorizeAsync(User, req.OrganizationId, "SameOrg");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }

            if (req.EmployeeId != null)
            {
                return BadRequest();
            }

            var success = await _serviceRequestService.ClaimRequestAsync(id , User.FindFirstValue(ClaimTypes.NameIdentifier));

            //should be employee requests
            return RedirectToPage("/Index");
        }
    }
}
