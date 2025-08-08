using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsSubscribe
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Target { get; set; }
        public int TargetId { get; set; }
        public DateTime Pubdate { get; set; }
    }
}
