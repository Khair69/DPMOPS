using DPMOPS.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace DPMOPS.Authorization.Handlers
{
    public class CitizenHandler : AuthorizationHandler<CitizenRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CitizenRequirement requirement)
        {
            var orgId = context.User.FindFirst("OrganizationId")?.Value;
            if (!context.User.HasClaim("IsAdmin","true") && orgId == null && context.User.Identity.IsAuthenticated)//should probably consider changing
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
