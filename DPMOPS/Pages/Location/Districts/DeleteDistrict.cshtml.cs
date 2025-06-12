#nullable disable
using DPMOPS.Services.District;
using DPMOPS.Services.District.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Location.Districts
{
    [Authorize("IsAdmin")]
    public class DeleteDistrictModel : PageModel
    {
        private readonly IDistrictService _districtService;
        static public Guid CityId { get; set; }

        public DeleteDistrictModel(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        public DistrictDto District { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            District = await _districtService.GetDistrictByIdAsync(id);
            if (District == null) 
            { 
                return NotFound();
            }

            CityId = District.CityId;

            return Page();
        }

        [FromForm]
        public Guid districtId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Page();
            }

            var successful = await _districtService.DeleteDistrictAsync(districtId);

            if (!successful)
            {
                return BadRequest();
            }

            return RedirectToPage("Index", new { cityId = CityId });
        }
    }
}
