using DPMOPS.Authorization.Requirements;
using DPMOPS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DPMOPS.Authorization.Handlers
{
    public class AdminOrOrgAdminInOrgHandler : AuthorizationHandler<AdminOrOrgAdminInOrgRequirement, Guid>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminOrOrgAdminInOrgHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminOrOrgAdminInOrgRequirement requirement, Guid resource)
        {
            // 1. Admins bypass org check
            if (context.User.HasClaim("IsAdmin", "true"))
            {
                context.Succeed(requirement);
                return;
            }

            // 2. Check for OrgAdmin claim and matching OrganizationId
            if (context.User.HasClaim("IsOrgAdmin", "true"))
            {
                var appUser = await _userManager.GetUserAsync(context.User);

                if (appUser != null && appUser.OrganizationId == resource)
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
}
