using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsNsTransaction
    {
        public uint Idtransaction { get; set; }
        public string TableName { get; set; }
        public string Differ { get; set; }
        public ulong? InTransaction { get; set; }
        public DateTime? Tstamp { get; set; }
    }
}
