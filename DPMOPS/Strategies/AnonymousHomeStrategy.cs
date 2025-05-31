using DPMOPS.Strategies.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Strategies
{
    public class AnonymousHomeStrategy : IHomePageStrategy
    {
        public async Task<IActionResult> GetPageResult(PageModel pageModel)
        {
            return pageModel.Page();
        }
    }
}
