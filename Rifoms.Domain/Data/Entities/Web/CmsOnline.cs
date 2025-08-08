using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsOnline
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string SessId { get; set; }
        public DateTime Lastdate { get; set; }
        public int UserId { get; set; }
        public string Agent { get; set; }
        public string Viewurl { get; set; }
    }
}
