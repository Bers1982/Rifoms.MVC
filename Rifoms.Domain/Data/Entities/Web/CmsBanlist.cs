using System;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsBanlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Ip { get; set; }
        public DateTime Bandate { get; set; }
        public int IntNum { get; set; }
        public string IntPeriod { get; set; }
        public bool? Status { get; set; }
        public bool Autodelete { get; set; }
        public string Cause { get; set; }
    }
}
