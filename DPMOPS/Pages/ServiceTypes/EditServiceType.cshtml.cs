using DPMOPS.Services.ServiceType;
using DPMOPS.Services.ServiceType.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.ServiceTypes
{
    [Authorize("IsAdmin")]
    public class EditServiceTypeModel : PageModel
    {
        private readonly IServiceTypeService _serviceTypeService;

        public EditServiceTypeModel(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        public ServiceTypeDto StDto { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            StDto = await _serviceTypeService.GetServiceTypeByIdAsync(id);
            if (StDto == null) 
            { 
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public UpdateServiceTypeDto StUpdateDto { get; set; }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            StUpdateDto.ServiceTypeId = id;
            var successful = await _serviceTypeService.UpdateServiceTypeAsync(StUpdateDto);

            if (!successful)
            {
                return BadRequest();
            }

            return RedirectToPage("Index");
        }
    }
}
