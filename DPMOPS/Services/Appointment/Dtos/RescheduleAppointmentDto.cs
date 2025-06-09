using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.Appointment.Dtos
{
    public class RescheduleAppointmentDto
    {
        public Guid AppointmentId { get; set; }

        [Required]
        public DateTime ScheduledAt { get; set; }
    }
}
