using DPMOPS.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace DPMOPS.Authorization.Handlers
{
    public class EmployeeHandler : AuthorizationHandler<EmployeeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmployeeRequirement requirement)
        {
            var orgId = context.User.FindFirst("OrganizationId")?.Value;
            var orgAdmin = context.User.FindFirst("IsOrgAdmin")?.Value;
            if (!string.IsNullOrEmpty(orgId) && string.IsNullOrEmpty(orgAdmin))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
