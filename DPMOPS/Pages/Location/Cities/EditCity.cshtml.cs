using DPMOPS.Services.City;
using DPMOPS.Services.City.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Location.Cities
{
    [Authorize("IsAdmin")]
    public class EditCityModel : PageModel
    {
        private readonly ICityService _cityService;

        public EditCityModel(ICityService cityService)
        {
            _cityService = cityService;
        }

        public CityDto CityDto { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            CityDto = await _cityService.GetCityByIdAsync(id);
            if (CityDto == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public UpdateCityDto CityUpdateDto { get; set; }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CityUpdateDto.CityId = id;
            var successful = await _cityService.UpdateCityAsync(CityUpdateDto);

            if (!successful)
            {
                return BadRequest();
            }

            return RedirectToPage("Index");
        }
    }
}
