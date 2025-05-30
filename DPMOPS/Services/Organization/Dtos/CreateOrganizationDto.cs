using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.Organization.Dtos
{
    public class CreateOrganizationDto
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} can't be shorter than {2} and longer than {1}", MinimumLength = 2)]
        [Display(Name = "Organization's Name")]
        public string? Name { get; set; }

        [Required]
        public Guid CityId { get; set; }
    }
}
