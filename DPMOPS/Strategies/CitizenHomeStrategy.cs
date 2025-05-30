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
    public class CitizenHomeStrategy : IHomePageStrategy
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CitizenHomeStrategy(IServiceRequestService serviceRequestService,
            UserManager<ApplicationUser> userManager)
        {
            _serviceRequestService = serviceRequestService;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetPageResult(PageModel pageModel)
        {
            //var user = await _userManager.Users.
            //    Include(u => u.Citizen)
            //    .FirstOrDefaultAsync(u => u.Id == pageModel.User.FindFirstValue(ClaimTypes.NameIdentifier));
            //Guid CId = user.Citizen.CitizenId;

            //var data = await _serviceRequestService.GetServiceRequestsByCitizenAsync(CId);

            pageModel.ViewData["UserType"] = "Citizen";
            //pageModel.ViewData["UserData"] = data;

            return pageModel.Page();
        }
    }
}
