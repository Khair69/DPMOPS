using DPMOPS.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Accounts
{
    public class RemoveAdminModel : PageModel
    {
        private readonly IUserService _userService;

        public RemoveAdminModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var succesful = await _userService.RemoveAdminAsync(id);
            if (!succesful)
            {
                return BadRequest();
            }
            return RedirectToPage("Index");
        }
    }
}
