using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace DPMOPS.Pages
{
    public class IndexModel : PageModel
    {
        public string? isAdmin { get; set; }
        public void OnGet()
        {
            isAdmin = User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value;
        }
    }
}
