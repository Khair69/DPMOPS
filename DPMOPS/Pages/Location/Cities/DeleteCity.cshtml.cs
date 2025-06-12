#nullable disable
using DPMOPS.Services.City;
using DPMOPS.Services.City.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Location.Cities
{
    [Authorize("IsAdmin")]
    public class DeleteCityModel : PageModel
    {
        private readonly ICityService _cityService;

        public DeleteCityModel(ICityService cityService)
        {
            _cityService = cityService;
        }

        public CityDto City { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            City = await _cityService.GetCityByIdAsync(id);
            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }

        [FromForm]
        public Guid cityId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var successful = await _cityService.DeleteCityAsync(cityId);

            if (!successful)
            {
                return BadRequest();
            }
            return RedirectToPage("Index");
        }
    }
}
