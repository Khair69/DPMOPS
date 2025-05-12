using DPMOPS.Models;

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
        public string? ProviderName { get; set; }
        public string? EmployeeName { get; set; }
        public string? ServiceType { get; set; }

        public Guid? CitizenId { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}
