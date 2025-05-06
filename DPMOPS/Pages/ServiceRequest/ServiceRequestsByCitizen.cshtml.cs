using DPMOPS.Models;
using DPMOPS.Services.Citizen;
using DPMOPS.Services.District;
using DPMOPS.Services.ServiceProvider;
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
    [Authorize]
    public class ServiceRequestsByCitizenModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServiceRequestsByCitizenModel(IServiceRequestService serviceRequestService, UserManager<ApplicationUser> userManager)
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
