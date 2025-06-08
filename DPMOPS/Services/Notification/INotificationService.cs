
using DPMOPS.Services.Notification.Dtos;

namespace DPMOPS.Services.Notification
{
    public interface INotificationService
    {
        Task<bool> SaveAsync(CreateNotificationDto notif);
        Task<IList<NotificationDto>> GetAllAsync(string userId);
        Task<IList<NotificationDto>> GetUnreadAsync(string userId);
        Task<bool> MarkAsReadAsync(Guid id);
        Task<NotificationDto> GetNotificationById(Guid id);
    }
}
