using DPMOPS.Services.City;
using DPMOPS.Services.City.Dtos;
using DPMOPS.Services.District;
using DPMOPS.Services.District.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Pages.Location.Districts
{
    public class AddDistrictModel : PageModel
    {
        private readonly IDistrictService _distictService;
        private readonly ICityService _cityService;

        public AddDistrictModel(IDistrictService districtService, ICityService cityService)
        {
            _distictService = districtService;
            _cityService = cityService;
        }

        [FromQuery]
        public Guid CId { get; set; }

        [BindProperty]
        public CreateDistrictDto DistrictDto { get; set; }

        public IEnumerable<SelectListItem> CityOptions { get; set; }

        public async Task OnGetAsync()
        {
            CityOptions = await _cityService.GetCityOptionsAsync();
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid)
            {
                CityOptions = await _cityService.GetCityOptionsAsync();
                return Page();
            }

            var successful = await _distictService.CreateDistrictAsync(DistrictDto);

            if (!successful)
            {
                return BadRequest();
            }

            return RedirectToPage("Index", new {cityId=DistrictDto.CityId});
        }
    }
}
