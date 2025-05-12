using DPMOPS.Services.Citizen;
using DPMOPS.Services.District;
using DPMOPS.Services.ServiceProvider;
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

        public IndexModel(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        public IList<ServiceRequestDto> ServiceRequests { get; set; }

        public async Task OnGetAsync()
        {
            ServiceRequests = await _serviceRequestService.GetAllServiceRequestsAsync();
        }
    }
}
