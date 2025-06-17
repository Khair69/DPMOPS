using DPMOPS.Models;
using DPMOPS.Services.Follow;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    public class PublicModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IFollowService _followService;
        private readonly IAuthorizationService _authService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PublicModel(IServiceRequestService serviceRequestService,
            IFollowService followService,
            IAuthorizationService authService,
            UserManager<ApplicationUser> userManager)
        {
            _serviceRequestService = serviceRequestService;
            _followService = followService;
            _authService = authService;
            _userManager = userManager;
        }

        public string Category { get; set; } = "All";
        public IList<ServiceRequestDto> Requests { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid CityId { get; set; }

        public async Task OnGetAsync(string category)
        {
            AuthorizationResult citAuth = await _authService.AuthorizeAsync(User, "IsCitizen");

            IList<ServiceRequestDto> temp_requests = new List<ServiceRequestDto>();
            if (User.Identity.IsAuthenticated)
            {
                if (CityId == Guid.Empty)
                {
                    CityId = _userManager.Users
                        .Where(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier))
                        .Include(u => u.District)
                        .Select(u => u.District.CityId)
                        .FirstOrDefault();
                }
                temp_requests = await _serviceRequestService.GetAllPublicServiceRequestsAsync(CityId);
            }
            else
            {
                if (CityId == Guid.Empty) temp_requests = await _serviceRequestService.GetAllPublicServiceRequestsAsync();
                else temp_requests = await _serviceRequestService.GetAllPublicServiceRequestsAsync(CityId);
            }



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
            
            Category = category ?? "All";

            Requests = Category switch
            {
                "All" => temp_requests,
                "Pending" => temp_requests.Where(sr => sr.Status == (Status)1).ToList(),
                "Accepted" => temp_requests.Where(sr => sr.Status == (Status)2).ToList(),
                "InProgress" => temp_requests.Where(sr => sr.Status == (Status)3).ToList(),
                "Suspended" => temp_requests.Where(sr => sr.Status == (Status)4).ToList(),
                "Denied" => temp_requests.Where(sr => sr.Status == (Status)5).ToList(),
                "Completed" => temp_requests.Where(sr => sr.Status == (Status)6).ToList(),
                "Explore" => temp_requests.Where(sr => sr.CitizenId != User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList(),
                _ => temp_requests
            };
        }
    }
}
