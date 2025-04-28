namespace DPMOPS.Services.ServiceProvider.Dtos
{
    public class ServiceProviderDto
    {
        public Guid ServiceProviderId { get; set; }

        public string? AccountId { get; set; }

        public string? ProviderName { get; set; }

        public Guid ServiceTypeId { get; set; }

        public string? ServiceType { get; set; }

        public string? ProviderEmail { get; set; }

        public Guid DistrictId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int NumberOfServiceRequests { get; set; }

        public int NumberOfReportRequests { get; set; }
    }
}
