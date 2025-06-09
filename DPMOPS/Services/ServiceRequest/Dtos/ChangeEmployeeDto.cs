using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.ServiceRequest.Dtos
{
    public class ChangeEmployeeDto
    {
        public Guid ServiceRequestId { get; set; }

        [Display(Name = "الموظف")]
        [Required(ErrorMessage = "{0} مطلوب")]
        public string? EmployeeId { get; set; }


    }
}
