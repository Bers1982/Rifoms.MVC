using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsMenu
    {
        public int Id { get; set; }
        public string Menu { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Linktype { get; set; }
        public string Linkid { get; set; }
        public string Target { get; set; }
        public string Component { get; set; }
        public int Ordering { get; set; }
        public bool Published { get; set; }
        public string Template { get; set; }
        public string AccessList { get; set; }
        public string Iconurl { get; set; }
        public int Nsleft { get; set; }
        public int Nsright { get; set; }
        public int Nslevel { get; set; }
        public string Nsdiffer { get; set; }
        public int Nsignore { get; set; }
        public int ParentId { get; set; }
    }
}
