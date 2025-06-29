using DPMOPS.Enums;
using DPMOPS.Models;
using DPMOPS.Models.ViewModels;
using DPMOPS.Services.City;
using DPMOPS.Services.Follow;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ICityService _cityService;

        public PublicModel(IServiceRequestService serviceRequestService,
            IFollowService followService,
            IAuthorizationService authService,
            UserManager<ApplicationUser> userManager,
            ICityService cityService)
        {
            _serviceRequestService = serviceRequestService;
            _followService = followService;
            _authService = authService;
            _userManager = userManager;
            _cityService = cityService;
        }

        public string Category { get; set; } = "all";
        public IList<ServiceRequestDto> Requests { get; set; }
        public IEnumerable<SelectListItem> CityOptions { get; set; }

        public PagingInfo pagingInfo { get; set; }
        public int PageSize = 8;

        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid CityId { get; set; }

        public async Task OnGetAsync(string category, string searchTerm, int pageNumber = 1)
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

            Category = category ?? "all";
            SearchTerm = searchTerm?.Trim();

            var filtered = Category.ToLower() switch
            {
                "all" => temp_requests,
                "pending" => temp_requests.Where(sr => sr.Status == (Status)1).ToList(),
                "accepted" => temp_requests.Where(sr => sr.Status == (Status)2).ToList(),
                "inprogress" => temp_requests.Where(sr => sr.Status == (Status)3).ToList(),
                "suspended" => temp_requests.Where(sr => sr.Status == (Status)4).ToList(),
                "denied" => temp_requests.Where(sr => sr.Status == (Status)5).ToList(),
                "completed" => temp_requests.Where(sr => sr.Status == (Status)6).ToList(),
                "explore" => temp_requests.Where(sr => sr.CitizenId != User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList(),
                _ => temp_requests
            };

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                filtered = filtered
                    .Where(sr =>
                        (!string.IsNullOrWhiteSpace(sr.Title) && sr.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrWhiteSpace(sr.Description) && sr.Description.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }

            Requests = filtered
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            pagingInfo = new PagingInfo
            {
                CurrentPage = pageNumber,
                ItemsPerPage = PageSize,
                TotalItems = filtered.Count
            };

            CityOptions = await _cityService.GetCityOptionsAsync();
        }
    }
}
