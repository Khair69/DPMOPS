namespace DPMOPS.Services.Appointment.Dtos
{
    public class AppointmentDto
    {
        public Guid AppointmentId { get; set; }

        public Guid ServiceRequestId { get; set; }

        public DateTime ScheduledAt { get; set; }

        public string? RequestTitle { get; set; }
    }
}
