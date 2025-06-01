using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsOrgAdmin")]
    public class ByOrgModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestsService;

        public ByOrgModel(IServiceRequestService serviceRequestService)
        {
            _serviceRequestsService = serviceRequestService;
        }

        public IList<ServiceRequestDto> ServiceRequests { get; set; }

        public async Task OnGetAsync()
        {
            var orgId = User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value;
            ServiceRequests = await _serviceRequestsService.GetServiceRequestsByOrganizationAsync(Guid.Parse(orgId));
        }
    }
}
