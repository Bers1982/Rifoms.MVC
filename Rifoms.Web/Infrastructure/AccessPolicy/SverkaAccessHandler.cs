using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

namespace Rifoms.Web.Infrastructure.Access
{
    public class SverkaAccessHandler : AuthorizationHandler<SverkaAccessRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            SverkaAccessRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "EnableSverka"))
            {
                if (Boolean.TryParse(context.User.FindFirst(c => c.Type == "EnableSverka").Value, out bool access))
                {
                    if (access == requirement.AccessSverka)
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
