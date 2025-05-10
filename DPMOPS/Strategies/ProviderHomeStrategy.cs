using DPMOPS.Models;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Strategies.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DPMOPS.Strategies
{
    public class ProviderHomeStrategy : IHomePageStrategy
    {

        public async Task<IActionResult> GetPageResult(PageModel pageModel)
        {
            pageModel.ViewData["UserType"] = "Provider";
            return pageModel.Page();
        }
    }
}
