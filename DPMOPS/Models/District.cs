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

        public City? City { get; set; }
        public ICollection<ApplicationUser>? Users { get; set; }
        public ICollection<ServiceRequest>? ServiceRequests { get; set; }
        public ICollection<ReportRequest>? ReportRequests { get; set; }
    }
}
