#nullable disable
using DPMOPS.Enums;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Pages.ServiceRequest
{
    [Authorize("IsCitizen")]
    public class ByCitizenModel : PageModel
    {
        private readonly IServiceRequestService _serviceRequestService;

        public ByCitizenModel(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        public string Category { get; set; } = "All";
        public IList<ServiceRequestDto> Requests { get; set; }

        public async Task OnGetAsync(string category)
        {
            Category = category ?? "All";

            IList<ServiceRequestDto> temp_requests = await _serviceRequestService.GetServiceRequestsByCitizenAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

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
