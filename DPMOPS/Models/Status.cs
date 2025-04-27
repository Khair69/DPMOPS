using System.ComponentModel.DataAnnotations;

namespace DPMOPS.Models
{
    public class Status
    {
        public Guid StatusId { get; set; }

        [Required]
        public string? State { get; set; }

        public ICollection<ServiceRequest>? ServiceRequests { get; set; }
        public ICollection<ReportRequest>? ReportRequests { get; set; }
    }
}
