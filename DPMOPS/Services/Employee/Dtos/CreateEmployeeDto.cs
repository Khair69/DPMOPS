using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.Employee.Dtos
{
    public class CreateEmployeeDto
    {
        [Required]
        public string? AccountId { get; set; }

        [Required]
        public Guid ServiceProviderId { get; set; }
    }
}
