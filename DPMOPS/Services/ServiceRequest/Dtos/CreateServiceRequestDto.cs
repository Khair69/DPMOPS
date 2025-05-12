using System.ComponentModel.DataAnnotations;

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

        public Guid? CitizenId { get; set; }
        [Required(ErrorMessage = "the service type field is required")]
        public Guid? EmployeeId { get; set; }
        [Required(ErrorMessage = "the district field is required")]
        public Guid? DistrictId { get; set; }
    }
}
