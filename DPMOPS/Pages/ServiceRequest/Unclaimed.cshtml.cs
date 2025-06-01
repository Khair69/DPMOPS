using DPMOPS.Services.ServiceRequest.Dtos;
using DPMOPS.Services.ServiceRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsEmployee")]
    public class UnclaimedModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestsService;

        public UnclaimedModel(IServiceRequestService serviceRequestService)
        {
            _serviceRequestsService = serviceRequestService;
        }

        public IList<ServiceRequestDto> ServiceRequests { get; set; }

        public async Task OnGetAsync()
        {
            var orgId = User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value;
            ServiceRequests = await _serviceRequestsService.GetUnclaimedRequestsByOrganizationAsync(Guid.Parse(orgId));
        }
    }
}
