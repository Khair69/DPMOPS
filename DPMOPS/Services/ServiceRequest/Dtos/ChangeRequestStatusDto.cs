namespace DPMOPS.Services.ServiceRequest.Dtos
{
    public class ChangeRequestStatusDto
    {
        public Guid ServiceRequestId { get; set; }

        public int StatusId { get; set; }
    }
}
