using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class Organization
    {
        public Guid OrganizationId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} can't be shorter than {2} and longer than {1}", MinimumLength = 2)]
        [Display(Name = "Organization's Name")]
        public string? Name { get; set; }

        [Required]
        public Guid CityId { get; set; }

        public City? City { get; set; }
        public ICollection<ApplicationUser>? Employees { get; set; }
        public ICollection<ServiceRequest>? ServiceRequests { get; set; }
    }
}
