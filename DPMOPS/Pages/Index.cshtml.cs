using DPMOPS.Strategies.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace DPMOPS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHomePageStrategyFactory _strategyFactory;

        public IndexModel(IHomePageStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var strategy = await _strategyFactory.CreateStrategyAsync(User);
            return await strategy.GetPageResult(this);
        }
    }
}
