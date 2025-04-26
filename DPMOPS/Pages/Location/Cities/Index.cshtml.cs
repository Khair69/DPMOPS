using DPMOPS.Services.City;
using DPMOPS.Services.City.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Location
{
    public class IndexModel : PageModel
    {
        private readonly ICityService _cityService;

        public IndexModel(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IList<CityDto> Cities { get; set; }

        public async Task OnGetAsync()
        {
            Cities = await _cityService.GetAllCitiesAsync();
        }
    }
}
