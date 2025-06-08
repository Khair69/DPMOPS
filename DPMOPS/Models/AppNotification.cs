using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;
using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class AppNotification
    {
        public Guid AppNotificationId { get; set; }

        [Required]
        public string? AccountId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Body { get; set; }

        [Required]
        public string? Link { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; } = false;

        public ApplicationUser? Account { get; set; }
    }
}
