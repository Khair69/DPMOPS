#nullable disable
using DPMOPS.Data;
using DPMOPS.Services.Appointment.Dtos;
using DPMOPS.Services.Notification;
using DPMOPS.Services.Notification.Dtos;
using DPMOPS.Services.ServiceRequest;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DPMOPS.Services.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceRequestService _serviceRequestService;
        private readonly LinkGenerator _linkGenerator;
        private readonly INotificationService _notificationService;

        public AppointmentService(ApplicationDbContext context,
            IServiceRequestService serviceRequestService,
            LinkGenerator linkGenerator,
            INotificationService notificationService)
        {
            _context = context;
            _serviceRequestService = serviceRequestService;
            _linkGenerator = linkGenerator;
            _notificationService = notificationService;
        }

        public async Task<bool> AddAppointmentAsync(CreateAppointmentDto apDto)
        {
            var request = await _serviceRequestService.GetServiceRequestByIdAsync(apDto.ServiceRequestId);
            if (request.AppointmentId == null)
            {
                var ap = new Models.Appointment 
                { 
                    AppointmentId = Guid.NewGuid(),
                    ServiceRequestId = apDto.ServiceRequestId,
                    ScheduledAt = apDto.ScheduledAt
                };

                _context.Appointments.Add(ap);
                var res = await _context.SaveChangesAsync();

                CreateNotificationDto notif = new CreateNotificationDto
                {
                    AccountId = request.CitizenId,
                    Title = $"تم تحديد موعد لطلبك \"{request.Title}\"",
                    Body = $"{apDto.ScheduledAt.ToString("dddd, dd MMMM yyyy - hh:mm tt", new CultureInfo("ar-SY"))}",
                    Link = _linkGenerator.GetPathByPage(
                        "/ServiceRequest/Info",
                        values: new { id = request.ServiceRequestId })
                };

                await _notificationService.SaveAsync(notif);

                return res == 1;
            }
            return false;
        }

        public async Task<IList<AppointmentDto>> GetCitizenAppointmentsAsync(string citId)
        {
            return await _context.Appointments
                .Include(a => a.ServiceRequest)
                .Where(a => a.ServiceRequest.CitizenId == citId)
                .Select(a => new AppointmentDto
                {
                    AppointmentId = a.AppointmentId,
                    ServiceRequestId = a.ServiceRequestId,
                    ScheduledAt = a.ScheduledAt,
                    RequestTitle = a.ServiceRequest.Title
                })
                .ToListAsync();
        }

        public async Task<IList<AppointmentDto>> GetEmployeeAppointmentsAsync(string empId)
        {
            return await _context.Appointments
                .Include(a => a.ServiceRequest)
                .Where(a => a.ServiceRequest.EmployeeId == empId)
                .Select(a => new AppointmentDto
                {
                    AppointmentId = a.AppointmentId,
                    ServiceRequestId = a.ServiceRequestId,
                    ScheduledAt = a.ScheduledAt,
                    RequestTitle = a.ServiceRequest.Title
                })
                .ToListAsync();
        }

        public async Task<IList<AppointmentDto>> GetOrganizationAppointmentsAsync(Guid orgId)
        {
            return await _context.Appointments
                .Include(a => a.ServiceRequest)
                .Where(a => a.ServiceRequest.OrganizationId == orgId)
                .Select(a => new AppointmentDto
                {
                    AppointmentId = a.AppointmentId,
                    ServiceRequestId = a.ServiceRequestId,
                    ScheduledAt= a.ScheduledAt,
                    RequestTitle = a.ServiceRequest.Title
                })
                .ToListAsync();
        }

        public Task<bool> RemoveAppointmentAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RescheduleAsync(RescheduleAppointmentDto apDto)
        {
            var existingAp = await _context.Appointments
                .Where(a => a.AppointmentId == apDto.AppointmentId)
                .Include(a => a.ServiceRequest)
                .FirstOrDefaultAsync();

            if (existingAp != null)
            {
                existingAp.ScheduledAt = apDto.ScheduledAt;
                var success = await _context.SaveChangesAsync();

                CreateNotificationDto notif = new CreateNotificationDto
                {
                    AccountId = existingAp.ServiceRequest.CitizenId,
                    Title = $"تم تغيير موعد طلبك \"{existingAp.ServiceRequest.Title}\"",
                    Body = $"{apDto.ScheduledAt.ToString("dddd, dd MMMM yyyy - hh:mm tt", new CultureInfo("ar-SY"))}",
                    Link = _linkGenerator.GetPathByPage(
                        "/ServiceRequest/Info",
                        values: new { id = existingAp.ServiceRequest.ServiceRequestId })
                };

                await _notificationService.SaveAsync(notif);

                return success == 1;
            }
            return false;
        }
    }
}
