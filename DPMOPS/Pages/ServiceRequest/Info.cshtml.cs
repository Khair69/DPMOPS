#nullable disable
using DPMOPS.Models;
using DPMOPS.Services.Account;
using DPMOPS.Services.Account.Dtos;
using DPMOPS.Services.Appointment;
using DPMOPS.Services.Appointment.Dtos;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize]
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
        public bool EmployeeViewer { get; set; } = false;
        public bool DeleteVisible { get; set; } = false;
        public bool OrgAdminViewer { get; set; } = false;
        public IEnumerable<SelectListItem> StatusOptions { get; set; }
        public AccountDto Citizen { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            ServiceRequest = await _serviceRequestService.GetServiceRequestByIdAsync(id);
            if (ServiceRequest == null)
            {
                return NotFound();
            }
            Citizen = await _accountService.GetAccountByIdAsync(ServiceRequest.CitizenId);

            AuthorizationResult authResult = await _authService.AuthorizeAsync(User, ServiceRequest, "OrgAdminOrYoursPub");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
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
                EmployeeViewer = true;
                ChangeStatus = new ChangeRequestStatusDto();
                ChangeStatus.StatusId = (int)ServiceRequest.Status;
            }
            if (ServiceRequest.CitizenId == User.FindFirstValue(ClaimTypes.NameIdentifier) && ServiceRequest.Status == (Status)1)
            {
                DeleteVisible = true;
            }
            if (User.HasClaim("IsOrgAdmin", "true"))
            {
                OrgAdminViewer = true;
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
