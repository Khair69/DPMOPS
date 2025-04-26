using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class City
    {
        public Guid CityId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The city's name can't be shorter than {2} and longer than {1}", MinimumLength = 2)]
        [Display(Name = "City's Name")]
        public string? Name { get; set; }

        public ICollection<District>? Districts { get; set; }
    }
}
