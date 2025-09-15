using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsEventHook
    {
        public int Id { get; set; }
        public string Event { get; set; }
        public string PluginId { get; set; }
    }
}
