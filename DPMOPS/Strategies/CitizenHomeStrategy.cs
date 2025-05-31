using DPMOPS.Services.ServiceRequest;
using DPMOPS.Strategies.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Strategies
{
    public class CitizenHomeStrategy : IHomePageStrategy
    {
        private readonly IServiceRequestService _serviceRequestService;

        public CitizenHomeStrategy(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        public async Task<IActionResult> GetPageResult(PageModel pageModel)
        {
            var userId = pageModel.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var data = await _serviceRequestService.GetServiceRequestsByCitizenAsync(userId);

            pageModel.ViewData["UserType"] = "Citizen";
            pageModel.ViewData["UserData"] = data;

            return pageModel.Page();
        }
    }
}
