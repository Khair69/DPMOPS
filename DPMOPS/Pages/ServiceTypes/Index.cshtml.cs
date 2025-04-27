using DPMOPS.Services.ServiceType;
using DPMOPS.Services.ServiceType.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPMOPS.Pages.ServiceTypes
{
    [Authorize("IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IServiceTypeService _serviceTypeService;

        public IndexModel(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        public IList<ServiceTypeDto> ServiceTypes { get; set; }

        public async Task OnGetAsync()
        {
            ServiceTypes = await _serviceTypeService.GetAllServiceTypesAsync();
        }
    }
}
