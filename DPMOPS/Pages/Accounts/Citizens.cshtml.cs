#nullable disable
using DPMOPS.Services.Account;
using DPMOPS.Services.Account.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Accounts
{
    [Authorize("IsAdmin")]
    public class CitizensModel : PageModel
    {
        private readonly IAccountService _accountService;

        public CitizensModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IList<AccountDto> Citizens { get; set; }

        public async Task OnGetAsync()
        {
            Citizens = await _accountService.GetCitizensAsync();
        }
    }
}
