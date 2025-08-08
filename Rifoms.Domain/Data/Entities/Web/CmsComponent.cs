using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsComponent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Config { get; set; }
        public int Internal { get; set; }
        public string Author { get; set; }
        public bool? Published { get; set; }
        public string Version { get; set; }
        public int System { get; set; }
    }
}
