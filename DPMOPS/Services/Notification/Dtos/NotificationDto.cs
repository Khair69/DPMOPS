namespace DPMOPS.Services.Notification.Dtos
{
    public class NotificationDto
    {
        public Guid AppNotificationId { get; set; }

        public string? AccountId { get; set; }

        public string? Title { get; set; }

        public string? Body { get; set; }

        public string? Link { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsRead { get; set; }
    }
}
