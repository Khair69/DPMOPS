using DPMOPS.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Accounts
{
    [Authorize("IsAdmin")]
    public class MakeAdminModel : PageModel
    {
        private readonly IUserService _userService;

        public MakeAdminModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            //should check if not allready admin
            var succesful = await _userService.MakeAdminAsync(id);
            if (!succesful)
            {
                return BadRequest();
            }
            return RedirectToPage("Index");
        }
    }
}
