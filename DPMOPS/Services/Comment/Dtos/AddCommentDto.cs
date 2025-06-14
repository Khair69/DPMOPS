using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.Comment.Dtos
{
    public class AddCommentDto
    {
        [Required]
        public string? AccountId { get; set; }

        public Guid ServiceRequestId { get; set; }

        [Required(ErrorMessage = "{0} مطلوب")]
        [Display(Name = "المحتوى")]
        [StringLength(100, ErrorMessage = "{0} يجب ان يكون اقصر من {1} حرف و اطول من {2} حرف ", MinimumLength = 2)]
        public string? Content { get; set; }
    }
}
