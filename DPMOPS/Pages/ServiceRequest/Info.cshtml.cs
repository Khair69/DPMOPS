using DPMOPS.Models;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.ServiceRequest
{
    public class InfoModel : PageModel
    {
        private readonly IAuthorizationService _authService;
        private readonly IServiceRequestService _serviceRequestService;

        public InfoModel(IAuthorizationService authService,
            IServiceRequestService serviceRequestService)
        {
            _authService = authService;
            _serviceRequestService = serviceRequestService;
        }

        public ServiceRequestDto ServiceRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            ServiceRequest = await _serviceRequestService.GetServiceRequestByIdAsync(id);

            AuthorizationResult authResult = await _authService.AuthorizeAsync(User, ServiceRequest, "IsUnclaimedOrYours");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }

            return Page();
        }

        [BindProperty]
        public ChangeRequestStatusDto ChangeStatus { get; set; }

        public async Task<IActionResult> OnPostStatusAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ChangeStatus.ServiceRequestId = id;
            var success = await _serviceRequestService.ChangeRequestStatusAsync(ChangeStatus);
            if (!success)
            {
                return BadRequest();
            }

            return RedirectToPage("Info");
        }
    }
}
