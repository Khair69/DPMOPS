using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.City.Dtos
{
    public class CreateCityDto
    {
        [Required(ErrorMessage ="اسم المدينة مطلوب")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name ="الاسم")]
        public string? Name { get; set; }
    }
}
