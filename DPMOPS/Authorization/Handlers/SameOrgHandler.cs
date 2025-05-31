using DPMOPS.Authorization.Requirements;
using DPMOPS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DPMOPS.Authorization.Handlers
{
    public class SameOrgHandler : AuthorizationHandler<SameOrgRequirement, Guid>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SameOrgHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, SameOrgRequirement requirement, Guid resource)
        {
            var appUser = await _userManager.GetUserAsync(context.User);
            if (appUser == null || appUser.OrganizationId == null) { return; }

            if (resource == appUser.OrganizationId)
            {
                context.Succeed(requirement);
            }
        }
    }
}
