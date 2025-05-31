using DPMOPS.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace DPMOPS.Authorization.Handlers
{
    public class AdminHandler : AuthorizationHandler<AdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            if (context.User.HasClaim("IsAdmin", "true"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
