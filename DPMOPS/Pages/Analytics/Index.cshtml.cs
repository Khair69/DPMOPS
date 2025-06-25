using DPMOPS.Services.Organization;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using DPMOPS.Services.UserClaim;
using DPMOPS.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Pages.Analytics
{
    public class IndexModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IOrganizationService _organizationService;
        private readonly IUserClaimService _userClaimService;
        public IndexModel(IServiceRequestService serviceRequestService,
            IOrganizationService organizationService,
            IUserClaimService userClaimService)           
        {
            _serviceRequestService = serviceRequestService;
            _organizationService = organizationService;
            _userClaimService = userClaimService;
        }

        public AnalyticsDto AnalyticsData { get; set; }
        public string OrgName { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userType = _userClaimService.ResolveUserType(User);
            IList<ServiceRequestDto> requests = new List<ServiceRequestDto>();
            if (userType == UserType.Admin)
            {
                OrgName = "الإحصائيات في النظام";
                requests = await _serviceRequestService.GetAllServiceRequestsAsync();
            }
            else if (userType == UserType.OrgAdmin)
            {
                Guid OrgId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value);
                var org = await _organizationService.GetOrganizationByIdAsync(OrgId);
                OrgName = "الإحصائيات في " + org.Name;
                requests = await _serviceRequestService.GetServiceRequestsByOrganizationAsync(OrgId);
                


            }
            else if (userType == UserType.Employee)
            {
                OrgName = "إحصائياتك";
                requests = await _serviceRequestService.GetServiceRequestsByEmployeeAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            else
            {
                return Forbid();
            }

            var now = DateTime.UtcNow;
            var today = now.Date;
            var weekStart = today.AddDays(-(int)today.DayOfWeek);
            var monthStart = new DateTime(now.Year, now.Month, 1);

            var completed = requests.Where(r => (int)r.Status == 6).ToList();
            var pending = requests.Where(r => (int)r.Status == 1).ToList();

            TimeSpan? avgResolution = completed.Any()
                ? TimeSpan.FromSeconds(completed
                    .Where(r => r.DateCompleted.HasValue && r.DateCreated != null)
                    .Average(r => (r.DateCompleted.Value - r.DateCreated).TotalSeconds))
                : null;

            AnalyticsData = new AnalyticsDto
            {
                StatusCounts = GetStatusCount(requests),
                TotalRequests = requests.Count,
                RequestsToday = requests.Count(r => r.DateCreated.Date == today),
                RequestsThisWeek = requests.Count(r => r.DateCreated.Date >= weekStart),
                RequestsThisMonth = requests.Count(r => r.DateCreated.Date >= monthStart),
                CompletedRequests = completed.Count,
                PendingRequests = pending.Count,
                AverageResolutionTime = avgResolution,
                AvarageRating = GetAvarageReview(completed),
                TrendData = GetRequestTrendPoints(requests)
            };
            return Page();
        }

        public Dictionary<string, int> GetStatusCount(IList<ServiceRequestDto> requests)
        {
            return requests
                .GroupBy(sr => sr.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Status.ToString(), x => x.Count);
        }

        public int GetAvarageReview(IList<ServiceRequestDto> compRequests)
        {
            if (compRequests.Count > 0)
            {
                int total = 0; int count = 0;
                foreach (var r in compRequests)
                {
                    if (r.Review != null)
                    {
                        total += (int)r.Review;
                        count++;
                    }
                }
                return (total / count);
            }
            return 0;
        }

        public List<RequestTrendPoint> GetRequestTrendPoints(IList<ServiceRequestDto> requests)
        {
            return requests
                .GroupBy(r => r.DateCreated.Date)
                .OrderBy(g => g.Key)
                .Select(g => new RequestTrendPoint
                {
                    Date = g.Key.ToString("yyyy-MM-dd"),
                    Count = g.Count()
                })
                .ToList();
        }
    }

    public class AnalyticsDto
    {
        public int TotalRequests { get; set; }
        public int RequestsToday { get; set; }
        public int RequestsThisMonth { get; set; }
        public int RequestsThisWeek { get; set; }

        public int CompletedRequests { get; set; }
        public int PendingRequests { get; set; }
        public double CompletionPercentage =>
        TotalRequests == 0 ? 0 : (double)CompletedRequests / TotalRequests * 100;

        public TimeSpan? AverageResolutionTime { get; set; }

        public Dictionary<string, int>? StatusCounts { get; set; }

        public int AvarageRating { get; set; }
        public List<RequestTrendPoint> TrendData { get; set; } = new();
    }

    public class RequestTrendPoint
    {
        public string Date { get; set; }
        public int Count { get; set; }
    }
}
