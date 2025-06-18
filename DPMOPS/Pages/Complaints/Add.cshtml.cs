using DPMOPS.Services.Complaint;
using DPMOPS.Services.Complaint.Dtos;
using DPMOPS.Services.ServiceRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DPMOPS.Pages.Complaints
{
    [Authorize("IsCitizen")]
    public class AddModel : PageModel
    {
        private readonly IComplaintService _complaintService;
        private readonly IServiceRequestService _serviceRequestService;

        public AddModel(IComplaintService complaintService,
            IServiceRequestService serviceRequestService)
        {
            _complaintService = complaintService;
            _serviceRequestService = serviceRequestService;
        }

        [BindProperty]
        public MakeComplaintDto NewComplaint { get; set; }
        
        public IEnumerable<SelectListItem> Requests { get; set; }

        public async Task OnGetAsync()
        {
            Requests = await _serviceRequestService.GetCitizenRequestsOptions(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Requests = await _serviceRequestService.GetCitizenRequestsOptions(User.FindFirstValue(ClaimTypes.NameIdentifier));

                return Page();
            }

            NewComplaint.CitizenId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var req = await _serviceRequestService.GetServiceRequestByIdAsync(NewComplaint.ServiceRequestId);
            NewComplaint.OrganizationId = (Guid)req.OrganizationId;

            var succ = await _complaintService.MakeComplaintAsync(NewComplaint);

            if (!succ) return BadRequest();

            return RedirectToPage("Index");
        }

    }
}
