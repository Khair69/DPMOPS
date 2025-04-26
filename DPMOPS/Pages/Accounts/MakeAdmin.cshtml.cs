using DPMOPS.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Accounts
{
    public class MakeAdminModel : PageModel
    {
        private readonly IUserService _userService;

        public MakeAdminModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var succesful = await _userService.MakeAdminAsync(id);
            if (!succesful)
            {
                return BadRequest();
            }
            return RedirectToPage("Index");
        }
    }
}
