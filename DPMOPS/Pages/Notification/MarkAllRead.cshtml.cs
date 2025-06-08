using DPMOPS.Services.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Pages.Notification
{
    public class MarkAllReadModel : PageModel
    {
        private readonly INotificationService _notificationService;

        public MarkAllReadModel(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Challenge();
            }

            await _notificationService.MarkAllReadAsync(userId);

            return Redirect(Request.Headers["Referer"].ToString() ?? "/");
        }
    }
}
