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

        public IndexModel(IServiceProviderService serviceProviderService,
             IDistrictService districtService)
        {
            _serviceProviderService = serviceProviderService;
        }

        public IList<ServiceProviderDto> Providers { get; set; }

        public async Task OnGet()
        {
            Providers = await _serviceProviderService.GetAllProvidersAsync();
        }
    }
}
