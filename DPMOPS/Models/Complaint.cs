#nullable disable
using DPMOPS.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DPMOPS.Models
{
    public class Complaint
    {
        public Guid ComplaintId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public string CitizenId { get; set; }
        public Guid OrganizationId { get; set; }

        public Guid ServiceRequestId { get; set; }

        public int Status { get; set; } = 1;

        public ApplicationUser Citizen { get; set; }
        public Organization Organization { get; set; }
        public ServiceRequest ServiceRequest { get; set; }
    }
}
