#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsCategory
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        public bool? Showdate { get; set; }
        public bool? Showcomm { get; set; }
        public string Orderby { get; set; }
        public string Orderto { get; set; }
        public int ModgrpId { get; set; }
        public int Nsleft { get; set; }
        public int Nsright { get; set; }
        public int Nslevel { get; set; }
        public string Nsdiffer { get; set; }
        public int Nsignore { get; set; }
        public int Ordering { get; set; }
        public int Maxcols { get; set; }
        public bool? Showtags { get; set; }
        public bool? Showrss { get; set; }
        public bool Showdesc { get; set; }
        public bool IsPublic { get; set; }
        public string Photoalbum { get; set; }
        public string Seolink { get; set; }
        public string Url { get; set; }
        public string Tpl { get; set; }
        public string Cost { get; set; }
    }
}
