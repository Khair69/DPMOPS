#nullable disable

using DPMOPS.Data;
using DPMOPS.Models;
using DPMOPS.Services.Notification.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DPMOPS.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<NotificationDto>> GetAllAsync(string userId)
        {
            return await _context.Notifications
                .Where(n => n.AccountId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NotificationDto
                {
                    AppNotificationId = n.AppNotificationId,
                    Title = n.Title,
                    Body = n.Body,
                    CreatedAt = n.CreatedAt,
                    IsRead = n.IsRead,
                    Link = n.Link
                }
                )
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<NotificationDto>> GetUnreadAsync(string userId)
        {
            return await _context.Notifications
                .Where(n => n.AccountId == userId && !n.IsRead)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NotificationDto
                {
                    AppNotificationId = n.AppNotificationId,
                    Title = n.Title,
                    Body = n.Body,
                    CreatedAt = n.CreatedAt,
                    Link = n.Link
                }
                )
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> SaveAsync(CreateNotificationDto notif)
        {
            var N = new AppNotification
            {
                AppNotificationId = Guid.NewGuid(),
                AccountId = notif.AccountId,
                Title = notif.Title,
                Body = notif.Body,
                Link = notif.Link
            };

            _context.Notifications.Add(N);
            var res = await _context.SaveChangesAsync();

            return res == 1;
        }

        public async Task<bool> MarkAsReadAsync(Guid id)
        {
            var notif = await _context.Notifications
                .FindAsync(id);

            if(notif != null)
            {
                notif.IsRead = true;
                var res = await _context.SaveChangesAsync();
                return res == 1;
            }

            return false;
        }

        public async Task<NotificationDto> GetNotificationById(Guid id)
        {
            return await _context.Notifications
                .Where(n => n.AppNotificationId == id)
                .Select(n => new NotificationDto
                {
                    AppNotificationId = n.AppNotificationId,
                    Title = n.Title,
                    Body = n.Body,
                    CreatedAt = n.CreatedAt,
                    IsRead = n.IsRead,
                    Link = n.Link,
                    AccountId = n.AccountId
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task MarkAllReadAsync(string userId)
        {
            var unreadNotifs = await _context.Notifications
                .Where(n => n.AccountId == userId && !n.IsRead)
                .ToListAsync();

            foreach (var notif in unreadNotifs)
            {
                notif.IsRead = true;
            }

            await _context.SaveChangesAsync();
            return;
        }
    }
}
