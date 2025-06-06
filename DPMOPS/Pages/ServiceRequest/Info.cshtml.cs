using DPMOPS.Models;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

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
        public bool ClaimVisible { get; set; } = false;
        public bool StatusVisible { get; set; } = false;
        public bool DeleteVisible { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            ServiceRequest = await _serviceRequestService.GetServiceRequestByIdAsync(id);

            if (ServiceRequest == null)
            {
                return NotFound();
            }

            AuthorizationResult authResult = await _authService.AuthorizeAsync(User, ServiceRequest, "IsUnclaimedOrYours");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }

            if (ServiceRequest.EmployeeId == null && !User.HasClaim("IsOrgAdmin", "true") && User.FindFirst("OrganizationId")?.Value != null)
            {
                ClaimVisible = true;
            }
            if (ServiceRequest.EmployeeId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                StatusVisible = true;
                ChangeStatus = new ChangeRequestStatusDto();
                ChangeStatus.StatusId = (int)ServiceRequest.Status;
            }
            if (ServiceRequest.CitizenId == User.FindFirstValue(ClaimTypes.NameIdentifier) && ServiceRequest.Status == (Status)1)
            {
                DeleteVisible = true;
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

            ServiceRequest = await _serviceRequestService.GetServiceRequestByIdAsync(id);
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != ServiceRequest.EmployeeId)
            {
                return new ForbidResult();
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
