using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class RequestFollower
    {
        public Guid Id { get; set; }

        [Required]
        public string? CitizenId { get; set; }
        [Required]
        public Guid ServiceRequestId { get; set; }
        [Required]
        public DateTime FollowedAt { get; set; } = DateTime.UtcNow;

        public ApplicationUser? User { get; set; }
        public ServiceRequest? ServiceRequest { get; set; }
    }
}
