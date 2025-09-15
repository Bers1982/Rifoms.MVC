using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsPhotoAlbum
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int Ordering { get; set; }
        public int Nsleft { get; set; }
        public int Nsright { get; set; }
        public string Nsdiffer { get; set; }
        public int Nsignore { get; set; }
        public int Nslevel { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        public bool? Showdate { get; set; }
        public string Iconurl { get; set; }
        public DateTime Pubdate { get; set; }
        public string Orderby { get; set; }
        public string Orderto { get; set; }
        public bool Public { get; set; }
        public int Perpage { get; set; }
        public string Cssprefix { get; set; }
        public int Thumb1 { get; set; }
        public int Thumb2 { get; set; }
        public bool? Thumbsqr { get; set; }
        public string Showtype { get; set; }
        public bool? Nav { get; set; }
        public int Uplimit { get; set; }
        public int Maxcols { get; set; }
        public bool? Orderform { get; set; }
        public bool? Showtags { get; set; }
        public bool? Bbcode { get; set; }
        public int UserId { get; set; }
        public bool IsComments { get; set; }
    }
}
