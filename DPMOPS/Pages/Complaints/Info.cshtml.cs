using DPMOPS.Enums;
using DPMOPS.Services.Complaint;
using DPMOPS.Services.Complaint.Dtos;
using DPMOPS.Services.UserClaim;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DPMOPS.Pages.Complaints
{
    public class InfoModel : PageModel
    {
        private readonly IComplaintService _complaintService;
        private readonly IUserClaimService _userClaimService;

        public InfoModel(IComplaintService complaintService,
            IUserClaimService userClaimService)
        {
            _complaintService = complaintService;
            _userClaimService = userClaimService;
        }

        public ComplaintDto Complaint { get; set; }

        public bool IsOrgAdmin { get; set; } = false;
        public bool IsCompleted { get; set; } = false;

        public IEnumerable<SelectListItem> Statuses { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            string? claim = User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value;
            Guid orgId = Guid.Empty;
            if (claim != null)
            {
                orgId = Guid.Parse(claim);
                IsOrgAdmin = true;
            }
            Complaint = await _complaintService.GetComplaintByIdAsync(id);

            if (Complaint == null) return NotFound();

            if (Complaint.CitizenId == User.FindFirstValue(ClaimTypes.NameIdentifier)
                || (Complaint.OrganizationId == orgId && User.HasClaim("IsOrgAdmin", "true"))
                || User.HasClaim("IsAdmin", "true"))
            {
                if (Complaint.StatusId == 3) IsCompleted = true;

                Statuses = Enum.GetValues(typeof(ComplaintStatus))
                    .Cast<ComplaintStatus>()
                    .Select(s => new SelectListItem
                    {
                        Value = ((int)s).ToString(),
                        Text = s.ToString()
                    })
                    .ToList();

                ChangeStatus = new ChangeComplaintStatusDto();
                ChangeStatus.StatusId = Complaint.StatusId;

                return Page();
            }

            return Forbid();
        }

        [BindProperty]
        public ChangeComplaintStatusDto ChangeStatus { get; set; }

        public async Task<IActionResult> OnPostStatusAsync(Guid id)
        {
            if (!ModelState.IsValid || IsCompleted)
            {
                return RedirectToPage("Info");
            }

            Complaint = await _complaintService.GetComplaintByIdAsync(id);
            if (Complaint == null) return NotFound();

            ChangeStatus.ComplaintId = id;
            var success = await _complaintService.ChangeComplaintStatus(ChangeStatus);
            if (!success)
            {
                return BadRequest();
            }

            return RedirectToPage("Info");

        }
    }
}
