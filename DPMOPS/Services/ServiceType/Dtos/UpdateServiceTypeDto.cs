using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.ServiceType.Dtos
{
    public class UpdateServiceTypeDto
    {
        public Guid ServiceTypeId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }
    }
}
