using DPMOPS.Models;
using DPMOPS.Services.Organization;
using DPMOPS.Strategies.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DPMOPS.Strategies
{
    public class OrgAdminHomeStrategy : IHomePageStrategy
    {
        private readonly IOrganizationService _organizationService;

        public OrgAdminHomeStrategy(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public async Task<IActionResult> GetPageResult(PageModel pageModel)
        {
            var OrgId = pageModel.User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value;

            var data = await _organizationService.GetOrganizationByIdAsync(Guid.Parse(OrgId));

            pageModel.ViewData["UserData"] = data;
            pageModel.ViewData["UserType"] = "OrgAdmin";

            return pageModel.Page();
        }
    }
}
