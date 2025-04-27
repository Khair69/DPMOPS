using DPMOPS.Services.City.Dtos;
using DPMOPS.Services.ServiceType;
using DPMOPS.Services.ServiceType.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.ServiceTypes
{
    [Authorize("IsAdmin")]
    public class AddServiceTypeModel : PageModel
    {
        private readonly IServiceTypeService _serviceTypeService;

        public AddServiceTypeModel(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        [BindProperty]
        public CreateServiceTypeDto StDto { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var successful = await _serviceTypeService.CreateServiceTypeAsync(StDto);

            if (!successful)
            {
                return BadRequest();
            }

            return RedirectToPage("Index");
        }
    }
}
