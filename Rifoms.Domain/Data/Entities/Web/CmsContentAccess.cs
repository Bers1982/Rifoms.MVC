using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsContentAccess
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public string ContentType { get; set; }
        public int GroupId { get; set; }
    }
}
