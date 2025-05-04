using DPMOPS.Services.Citizen;
using DPMOPS.Services.ServiceProvider;
using DPMOPS.Services.ServiceProvider.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Mono.TextTemplating;

namespace DPMOPS.Pages.ServiceProvider
{
    [Authorize("IsAdmin")]
    public class DeleteServiceProviderModel : PageModel
    {
        private readonly IServiceProviderService _serviceProviderService;
        private readonly ICitizenService _citizenService;

        public DeleteServiceProviderModel(IServiceProviderService serviceProviderService,
            ICitizenService citizenService)
        {
            _serviceProviderService = serviceProviderService;
            _citizenService = citizenService;
        }

        public ServiceProviderDto SpDto { get; set; }
        public static string AccId { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            SpDto = await _serviceProviderService.GetProviderByIdAsync(id);
            AccId = SpDto.AccountId;

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

            var successful2 = await _citizenService.CreateCitizenAsync(AccId);

            if (!successful2)
            {
                return BadRequest();
            }

            return RedirectToPage("Index");
        }

    }
}
