using DPMOPS.Services.ServiceProvider;
using DPMOPS.Services.ServiceProvider.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mono.TextTemplating;

namespace DPMOPS.Pages.ServiceProvider
{
    [Authorize("IsAdmin")]
    public class DeleteServiceProviderModel : PageModel
    {
        private readonly IServiceProviderService _serviceProviderService;

        public DeleteServiceProviderModel(IServiceProviderService serviceProviderService)
        {
            _serviceProviderService = serviceProviderService;
        }

        public ServiceProviderDto SpDto { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            SpDto = await _serviceProviderService.GetProviderByIdAsync(id);

            if (SpDto == null)
            {
                return NotFound();
            }
            return Page();
        }

        [FromForm]
        public Guid spId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var successful = await _serviceProviderService.DeleteServiceProviderAsync(spId);

            if (!successful)
            {
                return BadRequest();
            }
            return RedirectToPage("Index");
        }

    }
}
