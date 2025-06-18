#nullable disable
using DPMOPS.Enums;
using DPMOPS.Services.Follow;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsEmployee")]
    public class ByEmpModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IFollowService _followService;

        public ByEmpModel(IServiceRequestService serviceRequestService,
            IFollowService followService)
        {
            _serviceRequestService = serviceRequestService;
            _followService = followService;
        }

        public string Category { get; set; } = "All";
        public IList<ServiceRequestDto> Requests { get; set; }

        public async Task OnGetAsync(string category)
        {
            Category = category ?? "All";

            IList<ServiceRequestDto> temp_requests = await _serviceRequestService.GetServiceRequestsByEmployeeAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            foreach (var sr in temp_requests)
            {
                sr.FollowerCount = await _followService.GetRequestFollowCountAsync(sr.ServiceRequestId);
            }

            Requests = Category switch
            {
                "All" => temp_requests,
                "Accepted" => temp_requests.Where(sr => sr.Status == (Status)2).ToList(),
                "InProgress" => temp_requests.Where(sr => sr.Status == (Status)3).ToList(),
                "Suspended" => temp_requests.Where(sr => sr.Status == (Status)4).ToList(),
                "Denied" => temp_requests.Where(sr => sr.Status == (Status)5).ToList(),
                "Completed" => temp_requests.Where(sr => sr.Status == (Status)6).ToList(),
                _ => temp_requests
            };
        }
    }
}
