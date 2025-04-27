using DPMOPS.Models;
using DPMOPS.Services.ServiceType;
using DPMOPS.Services.ServiceType.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.ServiceTypes
{
    [Authorize("IsAdmin")]
    public class DeleteServiceTypeModel : PageModel
    {
        private readonly IServiceTypeService _serviceTypeService;

        public DeleteServiceTypeModel(IServiceTypeService serviceTypeService)
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

        [FromForm]
        public Guid stId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var successful = await _serviceTypeService.DeleteServiceTypeAsync(stId);

            if (!successful)
            {
                return BadRequest();
            }
            return RedirectToPage("Index");
        }
    }
}
