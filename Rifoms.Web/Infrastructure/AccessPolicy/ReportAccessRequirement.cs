using Microsoft.AspNetCore.Authorization;

namespace Rifoms.Web.Infrastructure.Access
{
    public class ReportAccessRequirement : IAuthorizationRequirement
    {
        protected internal bool AccessReport { get; set; }

        public ReportAccessRequirement(bool accessReport)
        {
            AccessReport = accessReport;
        }
    }
}
