using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.District.Dtos
{
    public class CreateDistrictDto
    {
        [Required (ErrorMessage = "{0} مطلوب")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "اسم المنطقة يجب ان يكون اقصر من {1} حرف و اطول من {2} حرف ", MinimumLength = 2)]
        [Display(Name = "الاسم")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} مطلوبة")]
        [Display(Name = "المدينة")]
        public string? CityId { get; set; }
    }
}
