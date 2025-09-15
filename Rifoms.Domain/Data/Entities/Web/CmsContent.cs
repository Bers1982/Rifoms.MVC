using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsContent
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public DateTime Pubdate { get; set; }
        public DateTime Enddate { get; set; }
        public bool IsEnd { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? Published { get; set; }
        public int Hits { get; set; }
        public int Rating { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKeys { get; set; }
        public bool? Showtitle { get; set; }
        public bool? Showdate { get; set; }
        public bool? Showlatest { get; set; }
        public bool? Showpath { get; set; }
        public int Ordering { get; set; }
        public bool? Comments { get; set; }
        public bool IsArhive { get; set; }
        public string Seolink { get; set; }
        public bool? Canrate { get; set; }
        public string Pagetitle { get; set; }
        public string Url { get; set; }
        public string Tpl { get; set; }
    }
}
