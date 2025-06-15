using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.Comment.Dtos
{
    public class CommentDto
    {
        public Guid CommentId { get; set; }

        [Required]
        public string? AccountId { get; set; }
        [Required]
        public string? UserName { get; set; }

        public Guid ServiceRequestId { get; set; }

        [Required]
        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
