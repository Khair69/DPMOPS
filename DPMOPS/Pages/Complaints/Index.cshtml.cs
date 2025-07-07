using DPMOPS.Services.Complaint;
using DPMOPS.Services.Complaint.Dtos;
using DPMOPS.Services.UserClaim;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Pages.Complaints
{
    public class IndexModel : PageModel
    {
        private readonly IComplaintService _complaintService;
        private readonly IUserClaimService _userClaimService;

        public IndexModel(IComplaintService complaintService,
            IUserClaimService userClaimService)
        {
            _complaintService = complaintService;
            _userClaimService = userClaimService;
        }

        public IList<ComplaintDto> Complaints { get; set; }

        public Enums.UserType userType { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            userType = _userClaimService.ResolveUserType(User);
            if (userType == Enums.UserType.Admin 
                || userType == Enums.UserType.OrgAdmin 
                || userType == Enums.UserType.Citizen)
            {
                switch (userType) 
                {
                    case Enums.UserType.Admin:
                        Complaints = await _complaintService.GetAllComplaintsAsync();
                        break;
                    case Enums.UserType.OrgAdmin:
                        Complaints = await _complaintService.GetOrgComplaintsAsync(Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value));
                        break;
                    case Enums.UserType.Citizen:
                        Complaints = await _complaintService.GetCitizenComplaintsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
                        break;
                }
            }
            else
            {
                return Forbid();
            }
            return Page();
        }
    }
}
