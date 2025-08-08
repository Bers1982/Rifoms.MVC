using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUserMsg
    {
        public int Id { get; set; }
        public int ToId { get; set; }
        public int FromId { get; set; }
        public DateTime Senddate { get; set; }
        public bool? IsNew { get; set; }
        public string Message { get; set; }
        public bool ToDel { get; set; }
        public bool FromDel { get; set; }
    }
}
