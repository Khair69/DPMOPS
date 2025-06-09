using DPMOPS.Data;
using DPMOPS.Services.Appointment.Dtos;
using DPMOPS.Services.ServiceRequest;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceRequestService _serviceRequestService;

        public AppointmentService(ApplicationDbContext context,
            IServiceRequestService serviceRequestService)
        {
            _context = context;
            _serviceRequestService = serviceRequestService;
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

                //notification to citizen.

                return res == 1;
            }
            return false;
        }

        public Task<IList<AppointmentDto>> GetCitizenAppointmentsAsync(string citId)
        {
            throw new NotImplementedException();
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

        public Task<bool> RemoveAppointmentAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RescheduleAsync(RescheduleAppointmentDto apDto)
        {
            var existingAp = await _context.Appointments
                .FindAsync(apDto.AppointmentId);

            if (existingAp != null)
            {
                existingAp.ScheduledAt = apDto.ScheduledAt;
                var success = await _context.SaveChangesAsync();
                return success == 1;

                //notification
            }
            return false;
        }
    }
}
