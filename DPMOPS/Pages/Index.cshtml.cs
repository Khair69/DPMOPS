using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace DPMOPS.Pages
{
    public class IndexModel : PageModel
    {
        public string? isAdmin { get; set; }
        public string? isCitizen { get; set; }
        public string? isProvider { get; set; }
        public void OnGet()
        {
            isAdmin = User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value;
            isCitizen = User.Claims.FirstOrDefault(x => x.Type == "IsCitizen")?.Value;
            isProvider = User.Claims.FirstOrDefault(x => x.Type == "IsProvider")?.Value;
        }
    }
}
