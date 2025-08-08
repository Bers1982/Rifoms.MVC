using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

namespace Rifoms.Web.Infrastructure.Access
{
    public class ZayavkaAccessHandler : AuthorizationHandler<ZayavkaAccessRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            ZayavkaAccessRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "EnableZayavka"))
            {
                //bool access = false;
                if (Boolean.TryParse(context.User.FindFirst(c => c.Type == "EnableZayavka").Value, out bool access))
                {
                    if (access == requirement.AccessZayavka)
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
