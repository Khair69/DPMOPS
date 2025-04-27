using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class Citizen
    {
        public Guid CitizenId { get; set; }

        [Required]
        public string? AccountId { get; set; }

        public ApplicationUser Account { get; set; }
    }
}
