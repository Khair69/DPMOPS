using DPMOPS.Models;
using System.Diagnostics.CodeAnalysis;

namespace DPMOPS.Services.ServiceRequest.Dtos
{
    public class ServiceRequestDto
    {
        public Guid ServiceRequestId { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? LocDescription { get; set; }
        public DateTime DateCreated { get; set; }

        public Guid? DistrictId { get; set; }
        public string? Address { get; set; }
        public Status Status { get; set; }

        public string? CitizenName { get; set; }
        public string? OrganizationName { get; set; }
        public string? EmployeeName { get; set; }

        public string? CitizenId { get; set; }
        public Guid? OrganizationId { get; set; }
        public string? EmployeeId { get; set; }

        public string? PhotoPath { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Guid? AppointmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }
}
