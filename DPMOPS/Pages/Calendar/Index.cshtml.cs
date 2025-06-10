using DPMOPS.Services.Appointment;
using DPMOPS.Services.Appointment.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Pages.Calendar
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public IndexModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult OnGet()
        {
            if (User.HasClaim("IsAdmin", "true"))
            {
                return new ForbidResult();
            }
            return Page();
        }

        public async Task<JsonResult> OnGetGetAppointmentsAsync()
        {
            IList<AppointmentDto> appointments = new List<AppointmentDto>();
            if (User.HasClaim("IsOrgAdmin", "true"))
            {
                var orgId = User.FindFirst("OrganizationId")?.Value;
                appointments = await _appointmentService.GetOrganizationAppointmentsAsync(Guid.Parse(orgId));
            }
            else if (User.FindFirst("OrganizationId")?.Value != null)
            {
                appointments = await _appointmentService.GetEmployeeAppointmentsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            else
            {
                appointments = await _appointmentService.GetCitizenAppointmentsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            var jsonAp = appointments.Select(a => new
            {
                title = a.RequestTitle,
                start = a.ScheduledAt.ToString("s")
            }).ToList();

            return new JsonResult(jsonAp);
        }
    }
}

