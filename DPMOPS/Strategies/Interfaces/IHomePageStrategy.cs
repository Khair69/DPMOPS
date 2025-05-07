using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Strategies.Interfaces
{
    public interface IHomePageStrategy
    {
        Task<IActionResult> GetPageResult(PageModel pageModel);
    }
}
