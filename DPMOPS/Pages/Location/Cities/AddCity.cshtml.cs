#nullable disable
using DPMOPS.Services.City;
using DPMOPS.Services.City.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Location
{
    [Authorize("IsAdmin")]
    public class AddCityModel : PageModel
    {
        private readonly ICityService _cityService;

        public AddCityModel(ICityService cityService)
        {
            _cityService = cityService;
        }

        [BindProperty]
        public CreateCityDto CityDto { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var successful = await _cityService.CreateCityAsync(CityDto);

            if (!successful)
            {
                return BadRequest();
            }

            return RedirectToPage("Index");
        }
    }
}
