using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class ServiceRequest
    {
        public Guid ServiceRequestId { get; set; }

        [Required]
        public string? LocDescription { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Reason {  get; set; }

        public Guid? CitizenId { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid? DistrictId { get; set; }
        public int StatusId { get; set; } = (int)Status.Pending;

        public Citizen? Citizen { get; set; }
        public Employee? Employee { get; set; }
        public District? District { get; set; }

        // possible add ons:
        // public DateTime? DateCompleted { get; set; }
        // public int? Rating { get; set; }
        // public string ServiceProviderNotes { get; set; }
        // public string ReportType { get; set; } // e.g., "Maintenance", "Complaint"
        // public string ImageUrl { get; set; } // For photo evidence
        // public bool IsUrgent { get; set; }
    }
}
