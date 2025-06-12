#nullable disable
using DPMOPS.Models;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsOrgAdmin")]
    public class ByOrgModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;

        public ByOrgModel(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        public string Category { get; set; } = "All";
        public IList<ServiceRequestDto> Requests { get; set; }

        public async Task OnGetAsync(string category)
        {
            Category = category ?? "All";

            var orgId = User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value;
            IList<ServiceRequestDto> temp_requests = await _serviceRequestService.GetServiceRequestsByOrganizationAsync(Guid.Parse(orgId));

            Requests = Category switch
            {
                "All" => temp_requests,
                "Pending" => temp_requests.Where(sr => sr.Status == (Status)1).ToList(),
                "Accepted" => temp_requests.Where(sr => sr.Status == (Status)2).ToList(),
                "InProgress" => temp_requests.Where(sr => sr.Status == (Status)3).ToList(),
                "Suspended" => temp_requests.Where(sr => sr.Status == (Status)4).ToList(),
                "Denied" => temp_requests.Where(sr => sr.Status == (Status)5).ToList(),
                "Completed" => temp_requests.Where(sr => sr.Status == (Status)6).ToList(),
                _ => temp_requests
            };
        }
    }
}
