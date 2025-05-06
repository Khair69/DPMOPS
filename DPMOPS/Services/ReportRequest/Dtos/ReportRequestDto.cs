namespace DPMOPS.Services.ReportRequest.Dtos
{
    public class ReportRequestDto
    {
        public Guid ReportRequestId { get; set; }

        public string? LocDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Description { get; set; }
        public string? Reason { get; set; }

        public Guid DistrictId { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }

        public string? CitizenName { get; set; }
        public string? ProviderName { get; set; }
        public string? ServiceType { get; set; }

        public Guid CitizenId { get; set; }
        public Guid ServiceProviderId { get; set; }
        public Guid StatusId { get; set; }
    }
}
