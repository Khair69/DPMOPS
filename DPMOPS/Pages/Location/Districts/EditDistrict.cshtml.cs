using DPMOPS.Services.City;
using DPMOPS.Services.District;
using DPMOPS.Services.District.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Pages.Location.Districts
{
    public class EditDistrictModel : PageModel
    {
        private readonly IDistrictService _districtService;
        private readonly ICityService _cityService;

        public EditDistrictModel(IDistrictService districtService, ICityService cityService)
        {
            _districtService = districtService;
            _cityService = cityService;
        }

        public DistrictDto DistrictDto { get; set; }

        [BindProperty]
        public UpdateDistrictDto DistrictUpdateDto { get; set; } = new UpdateDistrictDto();

        public IEnumerable<SelectListItem> CityOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            DistrictDto = await _districtService.GetDistrictByIdAsync(id);
            if (DistrictDto == null) 
            { 
                return NotFound();
            }
            DistrictUpdateDto.CityId = DistrictDto.CityId;
            CityOptions = await _cityService.GetCityOptionsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            DistrictUpdateDto.DistrictId = id;
            var successful = await _districtService.UpdateDistrictAsync(DistrictUpdateDto);

            if (!successful)
            {
                return BadRequest();
            }

            return RedirectToPage("Index", new {cityId = DistrictUpdateDto.CityId});

        }
    }
}
