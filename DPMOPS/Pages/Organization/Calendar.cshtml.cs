using DPMOPS.Services.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Pages.Organization
{
    [Authorize("IsEmployee")]
    public class CalendarModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public CalendarModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<JsonResult> OnGetGetAppointmentsAsync()
        {
            var appointments = await _appointmentService.GetEmployeeAppointmentsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var jsonAp = appointments.Select(a => new
            {
                title = a.RequestTitle,
                start = a.ScheduledAt.ToString("s")
            }).ToList();

            return new JsonResult(jsonAp);
        }
    }
}
