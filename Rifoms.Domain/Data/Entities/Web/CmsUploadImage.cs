using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUploadImage
    {
        public int Id { get; set; }
        public int TargetId { get; set; }
        public string SessionId { get; set; }
        public string Fileurl { get; set; }
        public string Target { get; set; }
        public string Component { get; set; }
    }
}
