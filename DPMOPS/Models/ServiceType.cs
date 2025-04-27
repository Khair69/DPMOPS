using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class ServiceType
    {
        public Guid ServiceTypeId { get; set; }

        [Required]
        public string? Name { get; set; }

        public ICollection<ServiceProvider>? ServiceProviders { get; set; }
    }
}
