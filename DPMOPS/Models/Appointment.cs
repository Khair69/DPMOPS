namespace DPMOPS.Models
{
    public class Appointment
    {
        public Guid AppointmentId { get; set; }

        public Guid ServiceRequestId { get; set; }

        public DateTime ScheduledAt { get; set; }

        public ServiceRequest? ServiceRequest { get; set; }
    }
}
