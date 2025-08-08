using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

namespace Rifoms.Web.Infrastructure.Access
{
    public class ClientAccessHandler : AuthorizationHandler<ClientAccessRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            ClientAccessRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "EnableClient"))
            {
                if (Boolean.TryParse(context.User.FindFirst(c => c.Type == "EnableClient").Value, out bool access))
                {
                    if (access == requirement.AccessClient)
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
