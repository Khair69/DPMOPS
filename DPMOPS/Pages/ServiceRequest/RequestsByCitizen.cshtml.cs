using DPMOPS.Models;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsCitizen")]
    public class RequestsByCitizenModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly UserManager<ApplicationUser> _userManager;

        public RequestsByCitizenModel(IServiceRequestService serviceRequestService, UserManager<ApplicationUser> userManager)
        {
            _serviceRequestService = serviceRequestService;
            _userManager = userManager;
        }

        public IList<ServiceRequestDto> ServiceRequests { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.Users.
                Include(u => u.Citizen)
                .FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid CId = user.Citizen.CitizenId;
            ServiceRequests = await _serviceRequestService.GetServiceRequestsByCitizenAsync(CId);
        }
    }
}
