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

        public string? Address { get; set; }

        public int NumberOfEmployees { get; set; }
    }
}
