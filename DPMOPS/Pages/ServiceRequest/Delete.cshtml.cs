using DPMOPS.Services.ServiceRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    public class DeleteModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;

        public DeleteModel(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var ServiceRequest = await _serviceRequestService.GetServiceRequestByIdAsync(id);

            if (ServiceRequest == null)
            {
                return NotFound();
            }

            if (ServiceRequest.CitizenId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return new ForbidResult();
            }

            var success = await _serviceRequestService.DeleteServiceRequestAsync(id);
            if (!success)
            {
                return BadRequest();
            }

            return RedirectToPage("/Index");
        }
    }
}
