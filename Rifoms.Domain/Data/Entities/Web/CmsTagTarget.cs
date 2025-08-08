using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsTagTarget
    {
        public int Id { get; set; }
        public string Target { get; set; }
        public string Component { get; set; }
        public string Title { get; set; }
    }
}
