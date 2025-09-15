using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUserKarma
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SenderId { get; set; }
        public short Points { get; set; }
        public DateTime Senddate { get; set; }
    }
}
