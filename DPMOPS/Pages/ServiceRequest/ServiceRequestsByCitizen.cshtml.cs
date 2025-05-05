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
        private readonly IDistrictService _districtService;
        private readonly ICitizenService _citizenService;
        private readonly IServiceProviderService _serviceProviderService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServiceRequestsByCitizenModel(IServiceRequestService serviceRequestService,
            IDistrictService districtService,
            ICitizenService citizenService,
            IServiceProviderService serviceProviderService,
            UserManager<ApplicationUser> userManager)
        {
            _serviceRequestService = serviceRequestService;
            _districtService = districtService;
            _citizenService = citizenService;
            _serviceProviderService = serviceProviderService;
            _userManager = userManager;
        }

        public IList<ServiceRequestDto> ServiceRequests { get; set; }
        public List<(ServiceRequestDto request, string location, string citizen, string provider, string serType)> RequestsWithInfo { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.Users.
                Include(u => u.Citizen)
                .FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid CId = user.Citizen.CitizenId;
            ServiceRequests = await _serviceRequestService.GetServiceRequestsByCitizenAsync(CId);
            RequestsWithInfo = new List<(ServiceRequestDto request, string location, string citizen, string provider, string serType)>();

            foreach (var sr in ServiceRequests)
            {
                var district = await _districtService.GetDistrictByIdAsync(sr.DistrictId);
                string loc = district.CityName + ", " + district.Name;

                var citizen = await _citizenService.GetCitizenByIdAsync(sr.CitizenId);
                string citName = citizen.CitizenName;

                var provider = await _serviceProviderService.GetProviderByIdAsync(sr.ServiceProviderId);
                string provName = provider.ProviderName;
                string serType = provider.ServiceType;

                RequestsWithInfo.Add((sr, loc, citName, provName, serType));
            }
        }
    }
}
