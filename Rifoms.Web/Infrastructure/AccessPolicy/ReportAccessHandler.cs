using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

namespace Rifoms.Web.Infrastructure.Access
{
    public class ReportAccessHandler : AuthorizationHandler<ReportAccessRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            ReportAccessRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "EnableReport"))
            {
                if (Boolean.TryParse(context.User.FindFirst(c => c.Type == "EnableReport").Value, out bool access))
                {
                    if (access == requirement.AccessReport)
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
