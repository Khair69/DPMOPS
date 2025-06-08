using DPMOPS.Services.Account;
using DPMOPS.Services.Account.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Accounts
{
    [Authorize("IsAdmin")]
    public class EmployeesModel : PageModel
    {
        private readonly IAccountService _accountService;

        public EmployeesModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IList<AccountDto> Employees { get; set; }

        public async Task OnGetAsync()
        {
            Employees = await _accountService.GetEmployeesAsync();
        }
    }
}
