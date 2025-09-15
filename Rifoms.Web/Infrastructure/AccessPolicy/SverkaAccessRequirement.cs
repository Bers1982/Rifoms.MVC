using Microsoft.AspNetCore.Authorization;

namespace Rifoms.Web.Infrastructure.Access
{
    public class SverkaAccessRequirement : IAuthorizationRequirement
    {
        protected internal bool AccessSverka { get; set; }

        public SverkaAccessRequirement(bool accessSverka)
        {
            AccessSverka = accessSverka;
        }
    }
}
