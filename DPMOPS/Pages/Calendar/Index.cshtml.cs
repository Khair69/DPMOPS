#nullable disable
using DPMOPS.Enums;
using DPMOPS.Services.Appointment;
using DPMOPS.Services.Appointment.Dtos;
using DPMOPS.Services.UserClaim;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Security.Claims;

namespace DPMOPS.Pages.Calendar
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUserClaimService _userClaimService;

        public IndexModel(IAppointmentService appointmentService,
            IUserClaimService userClaimService)
        {
            _appointmentService = appointmentService;
            _userClaimService = userClaimService;
        }

        public IActionResult OnGet()
        {
            var userType = _userClaimService.ResolveUserType(User);
            if (userType is UserType.Citizen or UserType.Employee or UserType.OrgAdmin)
            {
                return Page();
            }
            return Forbid();
        }

        public async Task<JsonResult> OnGetGetAppointmentsAsync()
        {
            IList<AppointmentDto> appointments = new List<AppointmentDto>();
            var userType = _userClaimService.ResolveUserType(User);
            if (userType == UserType.OrgAdmin)
            {
                var orgId = User.FindFirst("OrganizationId")?.Value;
                appointments = await _appointmentService.GetOrganizationAppointmentsAsync(Guid.Parse(orgId));
            }
            else if (userType == UserType.Employee)
            {
                appointments = await _appointmentService.GetEmployeeAppointmentsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            else if (userType == UserType.Citizen)
            {
                appointments = await _appointmentService.GetCitizenAppointmentsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            else
            {
                return new JsonResult("{}");
            }

            var jsonAp = appointments.Select(a => new
            {
                title = a.RequestTitle,
                start = a.ScheduledAt.ToString("s"),
                url = $"/ServiceRequest/Info/{a.ServiceRequestId}"
            }).ToList();

            return new JsonResult(jsonAp);
        }
    }
}

