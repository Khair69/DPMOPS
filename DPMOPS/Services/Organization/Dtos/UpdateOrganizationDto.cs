using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.Organization.Dtos
{
    public class UpdateOrganizationDto
    {
        public Guid OrganizationId { get; set; }

        [Required(ErrorMessage = "{0} مطلوب")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "{0} يجب ان يكون اقصر من {1} حرف و اطول من {2} حرف ", MinimumLength = 2)]
        [Display(Name = "الاسم")]
        public string? Name { get; set; }
    }
}
