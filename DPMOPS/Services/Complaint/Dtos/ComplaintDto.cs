#nullable disable
using DPMOPS.Enums;
using System.Diagnostics.CodeAnalysis;

namespace DPMOPS.Services.Complaint.Dtos
{
    public class ComplaintDto
    {
        public Guid ComplaintId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CitizenId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid ServiceRequestId { get; set; }
        public int StatusId { get; set; }

        public string CitizenName { get; set; }
        public string OrgName { get; set; }
        public string RequestTitle { get; set; }
        public ComplaintStatus Status { get; set; }
    }
}
