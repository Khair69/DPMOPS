using DPMOPS.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Accounts
{
    [Authorize("IsAdmin")]
    public class RemoveAdminModel : PageModel
    {
        private readonly IAccountService _accountService;

        public RemoveAdminModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var succesful = await _accountService.RemoveAdminAsync(id);
            if (!succesful)
            {
                return BadRequest();
            }
            return RedirectToPage("Index");
        }
    }
}
