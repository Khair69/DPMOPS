using DPMOPS.Authorization.Requirements;
using DPMOPS.Models;
using DPMOPS.Services.ServiceRequest.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DPMOPS.Authorization.Handlers
{
    public class OrgAdminOrYoursHandler : AuthorizationHandler<OrgAdminOrYoursRequirement, ServiceRequestDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public OrgAdminOrYoursHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OrgAdminOrYoursRequirement requirement, ServiceRequestDto resource)
        {
            //if it's yours bypass
            if (resource.EmployeeId == context.User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                context.Succeed(requirement);
                return;
            }

            if (resource.CitizenId == context.User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                context.Succeed(requirement);
                return;
            }

            //if you're the org admin and it's in the same org
            if (context.User.HasClaim("IsOrgAdmin", "true"))
            {
                var appUser = await _userManager.GetUserAsync(context.User);

                if (appUser != null && appUser.OrganizationId == resource.OrganizationId)
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
}
