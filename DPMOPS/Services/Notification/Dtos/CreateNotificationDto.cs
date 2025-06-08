using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.Notification.Dtos
{
    public class CreateNotificationDto
    {
        [Required]
        public string? AccountId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Body { get; set; }

        [Required]
        public string? Link { get; set; }
    }
}
