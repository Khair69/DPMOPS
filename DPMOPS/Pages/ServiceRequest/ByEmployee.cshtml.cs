using DPMOPS.Services.ServiceRequest.Dtos;
using DPMOPS.Services.ServiceRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsEmployee")]
    public class ByEmployeeModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestsService;

        public ByEmployeeModel(IServiceRequestService serviceRequestService)
        {
            _serviceRequestsService = serviceRequestService;
        }

        public IList<ServiceRequestDto> ServiceRequests { get; set; }

        public async Task OnGetAsync()
        {
            ServiceRequests = await _serviceRequestsService.GetServiceRequestsByEmployeeAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

    }
}
