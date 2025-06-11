using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages
{
    [Authorize("IsAdmin")]
    public class AdminHomeModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
