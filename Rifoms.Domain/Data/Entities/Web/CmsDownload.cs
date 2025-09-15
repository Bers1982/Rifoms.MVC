using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsDownload
    {
        public int Id { get; set; }
        public string Fileurl { get; set; }
        public int Hits { get; set; }
    }
}
