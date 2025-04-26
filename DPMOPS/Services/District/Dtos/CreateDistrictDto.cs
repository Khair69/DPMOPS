using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.District.Dtos
{
    public class CreateDistrictDto
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The district's name can't be shorter than {2} and longer than {1}", MinimumLength = 2)]
        [Display(Name = "District's Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "City")]
        public string? CityId { get; set; }
    }
}
