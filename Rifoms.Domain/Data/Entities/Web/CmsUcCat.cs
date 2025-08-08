using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUcCat
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? Published { get; set; }
        public string Fieldsstruct { get; set; }
        public string ViewType { get; set; }
        public int FieldsShow { get; set; }
        public bool? Showmore { get; set; }
        public int Perpage { get; set; }
        public bool? Showtags { get; set; }
        public bool? Showsort { get; set; }
        public bool IsRatings { get; set; }
        public string Orderby { get; set; }
        public string Orderto { get; set; }
        public bool? Showabc { get; set; }
        public bool Shownew { get; set; }
        public string Newint { get; set; }
        public int Filters { get; set; }
        public bool IsShop { get; set; }
        public int Nsleft { get; set; }
        public int Nsright { get; set; }
        public int Nslevel { get; set; }
        public int Nsdiffer { get; set; }
        public int Nsignore { get; set; }
        public int Ordering { get; set; }
        public bool IsPublic { get; set; }
        public int CanEdit { get; set; }
        public string Cost { get; set; }
    }
}
