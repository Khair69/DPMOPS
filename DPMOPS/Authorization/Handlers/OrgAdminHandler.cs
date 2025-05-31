using DPMOPS.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace DPMOPS.Authorization.Handlers
{
    public class OrgAdminHandler : AuthorizationHandler<OrgAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OrgAdminRequirement requirement)
        {
            if (context.User.HasClaim("IsOrgAdmin", "true"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
