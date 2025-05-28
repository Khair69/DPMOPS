using DPMOPS.Models;
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
    [Authorize("IsProvider")]
    public class ByProviderModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ByProviderModel(IServiceRequestService serviceRequestService,
            UserManager<ApplicationUser> userManager)
        {
            _serviceRequestService = serviceRequestService;
            _userManager = userManager;
        }

        public IList<ServiceRequestDto> Requests { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.Users.
                Include(u => u.ServiceProvider)
                .FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid PId = user.ServiceProvider.ServiceProviderId;
            Requests = await _serviceRequestService.GetServiceRequestsByProviderAsync(PId);
        }
    }
}
