using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DPMOPS.Services.ServiceRequest.Dtos
{
    public class CreateServiceRequestDto
    {
        [Required(ErrorMessage = "{0} مطلوب")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "{0} يجب ان يكون اقصر من {1} حرف و اطول من {2} حرف ", MinimumLength = 3)]
        [Display(Name = "وصف الموقع")]
        public string? LocDescription { get; set; }

        [Required(ErrorMessage = "{0} مطلوب")]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "{0} يجب ان يكون اقصر من {1} حرف و اطول من {2} حرف ", MinimumLength = 3)]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "{0} مطلوب")]
        [DataType(DataType.Text)]
        [StringLength(25, ErrorMessage = "{0} يجب ان يكون اقصر من {1} حرف و اطول من {2} حرف ", MinimumLength = 3)]
        [Display(Name = "العنوان")]
        public string? Title { get; set; }

        public string? CitizenId { get; set; }

        [AllowNull]
        public string? EmployeeId { get; set; }

        [Required(ErrorMessage = "{0} مطلوبة")]
        [Display(Name = "المؤسسة")]
        public Guid OrganizationId { get; set; }

        [Required(ErrorMessage = "{0} مطلوبة")]
        [Display(Name = "المنطقة")]
        public Guid? DistrictId { get; set; }

        [AllowNull]
        [Display(Name = "الصورة")]
        public IFormFile? PhotoFile { get; set; }
    }
}
