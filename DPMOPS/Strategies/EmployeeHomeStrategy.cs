using DPMOPS.Models;
using DPMOPS.Services.Organization;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Strategies.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DPMOPS.Strategies
{
    public class EmployeeHomeStrategy : IHomePageStrategy
    {
        private readonly IServiceRequestService _serviceRequestsService;

        public EmployeeHomeStrategy(IServiceRequestService serviceRequestsService)
        {
            _serviceRequestsService = serviceRequestsService;
        }

        public async Task<IActionResult> GetPageResult(PageModel pageModel)
        {
            var userId = pageModel.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var data = await _serviceRequestsService.GetServiceRequestsByEmployeeAsync(userId);

            pageModel.ViewData["UserData"] = data;
            pageModel.ViewData["UserType"] = "Employee";

            return pageModel.Page();
        }
    }
}
