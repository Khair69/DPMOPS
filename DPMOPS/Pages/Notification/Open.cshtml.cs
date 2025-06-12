#nullable disable
using DPMOPS.Services.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Pages.Notification
{
    public class OpenModel : PageModel
    {
        private readonly INotificationService _notificationService;

        public OpenModel(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var notif = await _notificationService.GetNotificationById(id);
            if (notif == null)
            {
                return NotFound();
            }

            if (notif.AccountId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Forbid();
            }

            if (!notif.IsRead)
            {
                var succ = await _notificationService.MarkAsReadAsync(id);

                if (succ) {
                    return Redirect(notif.Link);
                }
            }
            return Redirect("/");
        }
    }
}
