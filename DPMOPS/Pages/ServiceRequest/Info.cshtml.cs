using DPMOPS.Models;
using DPMOPS.Services.Account;
using DPMOPS.Services.Appointment;
using DPMOPS.Services.Appointment.Dtos;
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
        private readonly IAppointmentService _appointmentService;

        public InfoModel(IAuthorizationService authService,
            IServiceRequestService serviceRequestService,
            IAccountService accountService,
            IAppointmentService appointmentService)
        {
            _authService = authService;
            _serviceRequestService = serviceRequestService;
            _accountService = accountService;
            _appointmentService = appointmentService;
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

        [BindProperty(Name = "ChangeStatus")]
        public ChangeRequestStatusDto ChangeStatus { get; set; }

        public async Task<IActionResult> OnPostStatusAsync(Guid id)
        {
            RemoveUnrelatedModelState("ChangeStatus");
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Info");
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

        [BindProperty(Name = "ChangeEmployee")]
        public ChangeEmployeeDto ChangeEmployee { get; set; }

        public async Task<IActionResult> OnPostTransferAsync(Guid id)
        {
            RemoveUnrelatedModelState("ChangeEmployee");
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Info");
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

        [BindProperty(Name = "AddAppointment")]
        public CreateAppointmentDto AddAppointment {  get; set; }

        public async Task<IActionResult> OnPostAddAppointmentAsync(Guid id)
        {
            RemoveUnrelatedModelState("AddAppointment");
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Info");
            }

            var datePart = Request.Form["ScheduleDate"];
            var timePart = Request.Form["ScheduleTime"];

            if (DateTime.TryParse(datePart, out var date) && TimeSpan.TryParse(timePart, out var time))
            {
                AddAppointment.ScheduledAt = date.Date + time;
                AddAppointment.ServiceRequestId = id;
                var success = await _appointmentService.AddAppointmentAsync(AddAppointment);
                if (!success)
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }

            return RedirectToPage("Info");
        }

        [BindProperty(Name = "ReSchAppointment")]
        public RescheduleAppointmentDto ReSchAppointment { get; set; }

        public async Task<IActionResult> OnPostReSchAppointmentAsync()
        {
            RemoveUnrelatedModelState("ReSchAppointment");
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Info");
            }

            var datePart = Request.Form["ScheduleDate"];
            var timePart = Request.Form["ScheduleTime"];

            if (DateTime.TryParse(datePart, out var date) && TimeSpan.TryParse(timePart, out var time))
            {
                ReSchAppointment.ScheduledAt = date.Date + time;
                var success = await _appointmentService.RescheduleAsync(ReSchAppointment);
                if (!success)
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }

            return RedirectToPage("Info");
        }

        private void RemoveUnrelatedModelState(string prefixToKeep)
        {
            var keysToRemove = ModelState.Keys.Where(k => !k.StartsWith(prefixToKeep + ".", StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var key in keysToRemove)
            {
                ModelState.Remove(key);
            }
        }
    }
}
