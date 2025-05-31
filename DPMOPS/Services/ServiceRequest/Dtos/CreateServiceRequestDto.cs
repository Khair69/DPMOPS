using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DPMOPS.Services.ServiceRequest.Dtos
{
    public class CreateServiceRequestDto
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The location description can't be shorter than {2} and longer than {1}", MinimumLength = 3)]
        [Display(Name = "Location Description")]
        public string? LocDescription { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "The description can't be shorter than {2} and longer than {1}", MinimumLength = 3)]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "The title can't be shorter than {2} and longer than {1}", MinimumLength = 3)]
        public string? Title { get; set; }

        public string? CitizenId { get; set; }
        [AllowNull]
        public string? EmployeeId { get; set; }
        [Required(ErrorMessage = "the organization field is required")]
        public Guid OrganizationId { get; set; }
        [Required(ErrorMessage = "the district field is required")]
        public Guid? DistrictId { get; set; }
    }
}
