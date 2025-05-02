using DPMOPS.Services.Citizen;
using DPMOPS.Services.Citizen.Dtos;
using DPMOPS.Services.District;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Citizens
{
    [Authorize("IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly ICitizenService _citizenService;
        private readonly IDistrictService _districtService;

        public IndexModel(ICitizenService citizenService,
            IDistrictService districtService)
        {
            _citizenService = citizenService;
            _districtService = districtService;
        }

        public IList<CitizenDto> Citizens { get; set; }
        public List<(CitizenDto citizen, string location)> CitizensWithLocation { get; set; }

        public async Task OnGetAsync()
        {
            Citizens = await _citizenService.GetAllCitizensAsync();
            CitizensWithLocation = new List<(CitizenDto citizen, string location)>();
            foreach (var c in Citizens)
            {
                var district = await _districtService.GetDistrictByIdAsync(c.DistrictId);
                string loc = district.CityName + ", " + district.Name;
                CitizensWithLocation.Add((c, loc));
            }
        }
    }
}
