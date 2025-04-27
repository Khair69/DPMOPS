using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Services.ServiceType.Dtos
{
    public class ServiceTypeDto
    {
        public Guid ServiceTypeId { get; set; }

        [Required]
        public string? Name { get; set; }

        public int NumberOfProviders { get; set; }
    }
}
