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
        private readonly IServiceRequestService _serviceRequestService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProviderHomeStrategy(IServiceRequestService serviceRequestService,
            UserManager<ApplicationUser> userManager)
        {
            _serviceRequestService = serviceRequestService;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetPageResult(PageModel pageModel)
        {
            var user = await _userManager.Users.
                Include(u => u.ServiceProvider)
                .FirstOrDefaultAsync(u => u.Id == pageModel.User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid PId = user.ServiceProvider.ServiceProviderId;

            var data = await _serviceRequestService.GetServiceRequestsByProviderAsync(PId);

            pageModel.ViewData["UserType"] = "Provider";
            pageModel.ViewData["UserData"] = data;

            return pageModel.Page();
        }
    }
}
