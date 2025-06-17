namespace DPMOPS.Services.Follow.Dtos
{
    public class FollowingDto
    {
        public Guid Id { get; set; }

        public Guid ServiceRequestId { get; set; }

        public DateTime FollowedAt { get; set; }

        public string? RequestTitle { get; set; }

        public string? RequestOwnerName { get; set; }

        public int StatusId { get; set; }
    }
}
