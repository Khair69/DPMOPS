using DPMOPS.Services.Citizen.Dtos;
using DPMOPS.Services.District;
using DPMOPS.Services.ServiceProvider;
using DPMOPS.Services.ServiceProvider.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.ServiceProvider
{
    [Authorize("IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IServiceProviderService _serviceProviderService;
        private readonly IDistrictService _districtService;

        public IndexModel(IServiceProviderService serviceProviderService,
             IDistrictService districtService)
        {
            _serviceProviderService = serviceProviderService;
            _districtService = districtService;
        }

        public IList<ServiceProviderDto> Providers { get; set; }
        public List<(ServiceProviderDto provider, string location)> ProvidersWithLocation { get; set; }

        public async Task OnGet()
        {
            Providers = await _serviceProviderService.GetAllProvidersAsync();
            ProvidersWithLocation = new List<(ServiceProviderDto citizen, string location)>();
            foreach (var sp in Providers)
            {
                var district = await _districtService.GetDistrictByIdAsync(sp.DistrictId);
                string loc = district.CityName + ", " + district.Name;
                ProvidersWithLocation.Add((sp, loc));
            }
        }
    }
}
