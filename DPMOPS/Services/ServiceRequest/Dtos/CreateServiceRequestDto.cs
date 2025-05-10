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
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "The reason can't be shorter than {2} and longer than {1}", MinimumLength = 3)]
        [Display(Name = "Reson")]
        public string? Reason { get; set; }

        [Required]
        public Guid? CitizenId { get; set; }
        [Required]
        public Guid? EmployeeId { get; set; }
        [Required]
        public Guid? DistrictId { get; set; }
    }
}
