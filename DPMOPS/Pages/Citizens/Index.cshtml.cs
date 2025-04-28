using DPMOPS.Services.Citizen;
using DPMOPS.Services.Citizen.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.Citizens
{
    [Authorize("IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly ICitizenService _citizenService;

        public IndexModel(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public IList<CitizenDto> Citizens { get; set; }

        public async Task OnGetAsync()
        {
            Citizens = await _citizenService.GetAllCitizensAsync();
        }
    }
}
