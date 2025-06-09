using DPMOPS.Services.Appointment.Dtos;

namespace DPMOPS.Services.Appointment
{
    public interface IAppointmentService
    {
        Task<bool> AddAppointmentAsync(CreateAppointmentDto apDto);
        Task<bool> RescheduleAsync(RescheduleAppointmentDto apDto);
        Task<bool> RemoveAppointmentAsync(Guid id);
        Task<IList<AppointmentDto>> GetEmployeeAppointmentsAsync(string empId); 
        Task<IList<AppointmentDto>> GetCitizenAppointmentsAsync(string citId); 
    }
}
