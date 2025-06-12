using DPMOPS.Services.Account;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsOrgAdmin")]
    public class ChangeEmployeeModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IAccountService _accountService;

        public ChangeEmployeeModel(IServiceRequestService serviceRequestService, IAccountService accountService)
        {
            _serviceRequestService = serviceRequestService;
            _accountService = accountService;
        }

        [BindProperty]
        public AssignEmployeeDto ChangeEmployee { get; set; }

        public IEnumerable<SelectListItem> EmployeeOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var Sr = await _serviceRequestService.GetServiceRequestByIdAsync(id);
            if (Sr == null)
                return NotFound();

            if (!User.HasClaim("IsOrgAdmin", "true") &&
                User.FindFirst("OrganizationId")?.Value != Sr.OrganizationId.ToString())
            {
                return Forbid();
            }

            ChangeEmployee = new AssignEmployeeDto
            {
                ServiceRequestId = id,
                EmployeeId = Sr.EmployeeId
            };

            EmployeeOptions = await _accountService.GetEmployeesInOrgOptionsAsync(Guid.Parse(User.FindFirst("OrganizationId")?.Value));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                EmployeeOptions = await _accountService.GetEmployeesInOrgOptionsAsync(Guid.Parse(User.FindFirst("OrganizationId")?.Value));
                return Page();
            }

            var success = await _serviceRequestService.ChangeEmployeeAsync(ChangeEmployee);

            if (!success)
            {
                return BadRequest();
            }

            return Content("<script>window.parent.closeChangeModalAndRefresh();</script>", "text/html");
        }
    }

}
