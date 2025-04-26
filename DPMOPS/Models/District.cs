using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class District
    {
        public Guid DistrictId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The district's name can't be shorter than {2} and longer than {1}", MinimumLength = 2)]
        [Display(Name = "District's Name")]
        public string? Name { get; set; }

        public Guid CityId { get; set; }

        public virtual City? City { get; set; }
    }
}
