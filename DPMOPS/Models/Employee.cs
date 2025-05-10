using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }

        [Required]
        public string? AccountId { get; set; }

        public Guid ServiceProviderId { get; set; }

        public ApplicationUser? Account { get; set; }
        public ServiceProvider? ServiceProvider { get; set; }
        public ICollection<ServiceRequest>? ServiceRequests { get; set; }
    }
}
