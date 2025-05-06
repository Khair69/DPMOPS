using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class ReportRequest
    {
        public Guid ReportRequestId {  get; set; }

        [Required]
        public string? LocDescription { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Reason { get; set; }

        public Guid CitizenId { get; set; }
        public Guid ServiceProviderId { get; set; }
        public Guid DistrictId { get; set; }
        public int StatusId { get; set; } = 1;

        public Citizen? Citizen { get; set; }
        public ServiceProvider? ServiceProvider { get; set; }
        public District? District { get; set; }

        // possible add ons:
        // public string ReportType { get; set; } // e.g., "Maintenance", "Complaint"
        // public string ImageUrl { get; set; } // For photo evidence
        // public bool IsUrgent { get; set; }
    }
}
