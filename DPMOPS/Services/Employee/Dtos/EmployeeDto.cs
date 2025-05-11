namespace DPMOPS.Services.Employee.Dtos
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }

        public string? AccountId { get; set; }

        public string? EmployeeName { get; set; }

        public Guid ServiceProviderId { get; set; }

        public string? ProviderName { get; set; }

        public Guid ServiceTypeId { get; set; }

        public string? ServiceType { get; set; }

        public string? EmployeeEmail { get; set; }

        public Guid DistrictId { get; set; }

        public string? Address { get; set; }

        public int NumberOfServiceRequests { get; set; }
    }
}
