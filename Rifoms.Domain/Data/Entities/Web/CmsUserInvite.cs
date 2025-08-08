using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUserInvite
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int OwnerId { get; set; }
        public DateTime Createdate { get; set; }
        public bool IsUsed { get; set; }
        public bool IsSended { get; set; }
    }
}
