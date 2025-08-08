using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsPlugin
    {
        public int Id { get; set; }
        public string Plugin { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string PluginType { get; set; }
        public bool Published { get; set; }
        public string Config { get; set; }
    }
}
