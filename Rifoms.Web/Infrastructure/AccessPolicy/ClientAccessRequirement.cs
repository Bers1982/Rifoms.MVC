using Microsoft.AspNetCore.Authorization;

namespace Rifoms.Web.Infrastructure.Access
{
    public class ClientAccessRequirement : IAuthorizationRequirement
    {
        protected internal bool AccessClient { get; set; }

        public ClientAccessRequirement(bool accessClient)
        {
            AccessClient = accessClient;
        }
    }
}
