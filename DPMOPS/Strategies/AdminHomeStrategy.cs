using DPMOPS.Strategies.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Strategies
{
    public class AdminHomeStrategy : IHomePageStrategy
    {
        public async Task<IActionResult> GetPageResult(PageModel pageModel)
        {
            pageModel.ViewData["UserType"] = "Admin";
            return pageModel.Page();
        }
    }
}
