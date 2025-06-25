#nullable disable
using DPMOPS.Enums;
using DPMOPS.Models.ViewModels;
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
        public string CatName { get; set; } = "كل طلباتك";
        public IList<ServiceRequestDto> Requests { get; set; }

        public PagingInfo pagingInfo { get; set; }
        public int PageSize = 8;

        public string SearchTerm { get; set; }

        public async Task OnGetAsync(string category, string searchTerm,int pageNumber = 1)
        {
            Category = category ?? "All";
            SearchTerm = searchTerm?.Trim();

            IList<ServiceRequestDto> temp_requests = await _serviceRequestService.GetServiceRequestsByEmployeeAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            foreach (var sr in temp_requests)
            {
                sr.FollowerCount = await _followService.GetRequestFollowCountAsync(sr.ServiceRequestId);
            }

            var filtered = Category switch
            {
                "All" => temp_requests,
                "Accepted" => temp_requests.Where(sr => sr.Status == (Status)2).ToList(),
                "InProgress" => temp_requests.Where(sr => sr.Status == (Status)3).ToList(),
                "Suspended" => temp_requests.Where(sr => sr.Status == (Status)4).ToList(),
                "Denied" => temp_requests.Where(sr => sr.Status == (Status)5).ToList(),
                "Completed" => temp_requests.Where(sr => sr.Status == (Status)6).ToList(),
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

            CatName = Category switch
            {
                "All" => "كل طلباتك",
                "Accepted" => "طلباتك المقبولة",
                "InProgress" => "طلباتك القيد العمل",
                "Suspended" => "طلباتك المعلقة",
                "Denied" => "طلباتك المرفوضة",
                "Completed" => "طلباتك المكتملة",
                _ => "طلباتك"
            };

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
        }
    }
}
