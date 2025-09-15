using Microsoft.AspNetCore.Authorization;

namespace Rifoms.Web_new.Infrastructure.Access
{
    public class ZayavkaAccessRequirement : IAuthorizationRequirement
    {
        protected internal bool AccessZayavka { get; set; }
        public ZayavkaAccessRequirement(bool accessZayavka)
        {
            AccessZayavka = accessZayavka;
        }
    }
}
