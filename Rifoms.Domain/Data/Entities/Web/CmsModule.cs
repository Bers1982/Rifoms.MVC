using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsModule
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool IsExternal { get; set; }
        public string Content { get; set; }
        public int Ordering { get; set; }
        public int Showtitle { get; set; }
        public bool? Published { get; set; }
        public int User { get; set; }
        public string Config { get; set; }
        public int Original { get; set; }
        public string CssPrefix { get; set; }
        public string AccessList { get; set; }
        public int Cache { get; set; }
        public int Cachetime { get; set; }
        public string Cacheint { get; set; }
        public string Template { get; set; }
        public bool IsStrictBind { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
    }
}
