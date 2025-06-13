#nullable disable
using DPMOPS.Services.Follow;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IFollowService _followService;

        public IndexModel(IServiceRequestService serviceRequestService,
            IFollowService followService)
        {
            _serviceRequestService = serviceRequestService;
            _followService = followService;
        }

        public IList<ServiceRequestDto> ServiceRequests { get; set; }

        public async Task OnGetAsync()
        {
            ServiceRequests = await _serviceRequestService.GetAllServiceRequestsAsync();

            foreach (var sr in ServiceRequests)
            {
                sr.FollowerCount = await _followService.GetRequestFollowCountAsync(sr.ServiceRequestId);
            }
        }
    }
}
