using DPMOPS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DPMOPS.ViewComponents
{
    public class UserDisplayNameViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserDisplayNameViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var name = user?.FirstName + " " + user?.LastName ?? "Guest";
            return View("Default", name);
        }
    }

}
