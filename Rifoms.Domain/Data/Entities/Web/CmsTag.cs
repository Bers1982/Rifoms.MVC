using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsTag
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Target { get; set; }
        public int ItemId { get; set; }
    }
}
