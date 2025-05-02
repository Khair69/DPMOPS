using DPMOPS.Services.ServiceProvider;
using DPMOPS.Services.ServiceProvider.Dtos;
using DPMOPS.Services.ServiceType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Pages.ServiceProvider
{
    [Authorize("IsAdmin")]
    public class EditServiceProviderModel : PageModel
    {
        private readonly IServiceProviderService _serviceProviderService;
        private readonly IServiceTypeService _serviceTypeService;

        public EditServiceProviderModel(IServiceProviderService serviceProviderService,
            IServiceTypeService serviceTypeService)
        {
            _serviceProviderService = serviceProviderService;
            _serviceTypeService = serviceTypeService;
        }

        public ServiceProviderDto SpDto { get; set; }
        public IEnumerable<SelectListItem> ServiceTypeOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            SpDto = await _serviceProviderService.GetProviderByIdAsync(id);
            if (SpDto == null)
            {
                return NotFound();
            }

            ServiceTypeOptions = await _serviceTypeService.GetServiceTypeOptionsAsync();

            return Page();
        }

        [BindProperty]
        public UpdateServiceProviderDto SpUpdateDto { get; set; }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                ServiceTypeOptions = await _serviceTypeService.GetServiceTypeOptionsAsync();
                return Page();
            }
            SpUpdateDto.ServiceProviderId = id;
            var successful = await _serviceProviderService.UpdateServiceProviderAsync(SpUpdateDto);

            if (!successful)
            {
                return BadRequest();
            }

            return RedirectToPage("Index");
        }
    }
}
