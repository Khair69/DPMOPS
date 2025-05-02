using DPMOPS.Services.Citizen;
using DPMOPS.Services.District;
using DPMOPS.Services.ServiceProvider;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.ServiceRequest
{
    public class IndexModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IDistrictService _districtService;
        private readonly ICitizenService _citizenService;
        private readonly IServiceProviderService _serviceProviderService;

        public IndexModel(IServiceRequestService serviceRequestService, 
            IDistrictService districtService,
            ICitizenService citizenService,
            IServiceProviderService serviceProviderService)
        {
            _serviceRequestService = serviceRequestService;
            _districtService = districtService;
            _citizenService = citizenService;
            _serviceProviderService = serviceProviderService;
        }

        public IList<ServiceRequestDto> ServiceRequests { get; set; }
        public List<(ServiceRequestDto request, string location, string citizen, string provider, string serType)> RequestsWithInfo { get; set; }

        public async Task OnGetAsync()
        {
            ServiceRequests = await _serviceRequestService.GetAllServiceRequestsAsync();
            RequestsWithInfo = new List<(ServiceRequestDto request, string location, string citizen, string provider, string serType)>();

            foreach(var sr in ServiceRequests)
            {
                var district = await _districtService.GetDistrictByIdAsync(sr.DistrictId);
                string loc = district.CityName + ", " + district.Name;

                var citizen = await _citizenService.GetCitizenByIdAsync(sr.CitizenId);
                string citName = citizen.CitizenName;

                var provider = await _serviceProviderService.GetProviderByIdAsync(sr.ServiceProviderId);
                string provName = provider.ProviderName;
                string serType = provider.ServiceType;

                RequestsWithInfo.Add((sr,loc,citName,provName,serType));
            }
        }
    }
}
