using DPMOPS.Models;
using DPMOPS.Services.Follow;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize]
    public class PublicModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IFollowService _followService;
        private readonly IAuthorizationService _authService;

        public PublicModel(IServiceRequestService serviceRequestService,
            IFollowService followService,
            IAuthorizationService authService)
        {
            _serviceRequestService = serviceRequestService;
            _followService = followService;
            _authService = authService;
        }

        public string Category { get; set; } = "All";
        public IList<ServiceRequestDto> Requests { get; set; }

        public async Task OnGetAsync(string category)
        {
            Category = category ?? "All";

            IList<ServiceRequestDto> temp_requests = await _serviceRequestService.GetAllPublicServiceRequestsAsync();

            AuthorizationResult citAuth = await _authService.AuthorizeAsync(User, "IsCitizen");

            foreach (var sr in temp_requests)
            {
                sr.FollowerCount = await _followService.GetRequestFollowCountAsync(sr.ServiceRequestId);
                sr.IsFollowing = await _followService.UserIsFollowingReqAsync(new Services.Follow.Dtos.FollowDto
                {
                    CitizenId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    ServiceRequestId = sr.ServiceRequestId
                });
                sr.FollowVisible = (sr.CitizenId != User.FindFirstValue(ClaimTypes.NameIdentifier) && citAuth.Succeeded) ? true : false;
            }

            Requests = Category switch
            {
                "All" => temp_requests,
                "Pending" => temp_requests.Where(sr => sr.Status == (Status)1).ToList(),
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
