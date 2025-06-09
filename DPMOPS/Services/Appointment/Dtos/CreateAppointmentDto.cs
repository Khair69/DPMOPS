using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.Appointment.Dtos
{
    public class CreateAppointmentDto
    {
        [Required]
        public Guid ServiceRequestId { get; set; }

        [Required]
        public DateTime ScheduledAt { get; set; }
    }
}
