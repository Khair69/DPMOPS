using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }

        [Required]
        public string? AccountId { get; set; }

        public Guid ServiceRequestId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ApplicationUser? Account { get; set; }
        public ServiceRequest? ServiceRequest { get; set; }
    }
}
