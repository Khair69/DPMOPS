namespace DPMOPS.Services.ServiceRequest.Dtos
{
    public class ServiceRequestDto
    {
        public Guid ServiceRequestId { get; set; }

        public string? LocDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Description { get; set; }
        public string? Reason { get; set; }

        public Guid DistrictId { get; set; }
        public string? Status { get; set; }

        public Guid CitizenId { get; set; }
        public Guid ServiceProviderId { get; set; }
        public Guid StatusId { get; set; }
    }
}
