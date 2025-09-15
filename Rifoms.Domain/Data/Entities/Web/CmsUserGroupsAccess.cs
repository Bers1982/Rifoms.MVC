using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUserGroupsAccess
    {
        public uint Id { get; set; }
        public string AccessType { get; set; }
        public string AccessName { get; set; }
    }
}
