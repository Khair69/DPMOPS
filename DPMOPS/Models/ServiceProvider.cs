using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class ServiceProvider
    {
        public Guid ServiceProviderId { get; set; }

        [Required]
        public string? AccountId { get; set; }

        public Guid ServiceTypeId { get; set; }

        public ApplicationUser Account { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
