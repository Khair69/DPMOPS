using DPMOPS.Models;
using DPMOPS.Services.Account;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    public class InfoModel : PageModel
    {
        private readonly IAuthorizationService _authService;
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IAccountService _accountService;

        public InfoModel(IAuthorizationService authService,
            IServiceRequestService serviceRequestService,
            IAccountService accountService)
        {
            _authService = authService;
            _serviceRequestService = serviceRequestService;
            _accountService = accountService;
        }

        public ServiceRequestDto ServiceRequest { get; set; }
        public bool ClaimVisible { get; set; } = false;
        public bool StatusVisible { get; set; } = false;
        public bool DeleteVisible { get; set; } = false;
        public bool TransferVisible { get; set; } = false;
        public IEnumerable<SelectListItem> EmployeeOptions { get; set; }
        public IEnumerable<SelectListItem> StatusOptions { get; set; }

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
                StatusOptions = Enum.GetValues(typeof(Status))
                    .Cast<Status>()
                    .Where(s => s != (Status)1)
                    .Select(s => new SelectListItem
                    {
                        Value = ((int)s).ToString(),
                        Text = s.ToString()
                    })
                    .ToList();
                StatusVisible = true;
                ChangeStatus = new ChangeRequestStatusDto();
                ChangeStatus.StatusId = (int)ServiceRequest.Status;
            }
            if (ServiceRequest.CitizenId == User.FindFirstValue(ClaimTypes.NameIdentifier) && ServiceRequest.Status == (Status)1)
            {
                DeleteVisible = true;
            }
            if (User.HasClaim("IsOrgAdmin", "true") && ServiceRequest.OrganizationId.ToString() == User.FindFirst("OrganizationId")?.Value)
            {
                EmployeeOptions = await _accountService.GetEmployeeInOrgOptionsAsync(Guid.Parse(User.FindFirst("OrganizationId")?.Value));
                TransferVisible = true;
                ChangeEmployee = new ChangeEmployeeDto();
                ChangeEmployee.EmployeeId = ServiceRequest.EmployeeId;
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

        [BindProperty]
        public ChangeEmployeeDto ChangeEmployee { get; set; }

        public async Task<IActionResult> OnPostTransferAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ServiceRequest = await _serviceRequestService.GetServiceRequestByIdAsync(id);
            if (User.FindFirst("OrganizationId")?.Value != ServiceRequest.OrganizationId.ToString() && !User.HasClaim("IsOrgAdmin", "true"))
            {
                return new ForbidResult();
            }

            ChangeEmployee.ServiceRequestId = id;
            var success = await _serviceRequestService.ChangeRequestsEmployeeAsync(ChangeEmployee);
            if (!success)
            {
                return BadRequest();
            }

            return RedirectToPage("Info");
        }
    }
}
