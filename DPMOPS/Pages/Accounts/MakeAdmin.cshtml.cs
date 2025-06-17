using DPMOPS.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Accounts
{
    [Authorize("IsAdmin")]
    public class MakeAdminModel : PageModel
    {
        private readonly IAccountService _accountService;

        public MakeAdminModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            //should check if not allready admin
            var succesful = await _accountService.MakeAdminAsync(id);
            if (!succesful)
            {
                return BadRequest();
            }
            return RedirectToPage("Index");
        }
    }
}
