using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.ServiceType.Dtos
{
    public class CreateServiceTypeDto
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }
    }
}
