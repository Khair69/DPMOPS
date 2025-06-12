#nullable disable
using DPMOPS.Services.City;
using DPMOPS.Services.City.Dtos;
using DPMOPS.Services.District;
using DPMOPS.Services.District.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Location.Districts
{
    [Authorize("IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IDistrictService _districtService;
        private readonly ICityService _cityService;

        public IndexModel(IDistrictService districtService, ICityService cityService)
        {
            _districtService = districtService;
            _cityService = cityService;
        }

        public CityDto City { get; set; }
        public IList<DistrictDto> Districts { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid cityId)
        {
            City = await _cityService.GetCityByIdAsync(cityId);
            if (City == null) 
                return NotFound();
            Districts = await _districtService.GetDistrictByCityAsync(cityId);

            return Page();
        }
    }
}
