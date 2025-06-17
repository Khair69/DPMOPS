using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize]
    public class MapModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;

        public MapModel(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        public IList<MapPointDto> MapPoints { get; set; }

        public async Task OnGetAsync(string category)
        {
            Guid? orgId = null;

            var orgClaim = User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value;

            if (Guid.TryParse(orgClaim, out Guid parsedOrgId))
            {
                orgId = parsedOrgId;
            }

            if (orgId.HasValue)
            {
                MapPoints = await _serviceRequestService.GetLocationsByOrg(orgId.Value);
            }
            else
            {
                MapPoints = await _serviceRequestService.GetAllLocations();
            }

        }
    }
}
