using System;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsComment
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int Pid { get; set; }
        public int UserId { get; set; }
        public string Target { get; set; }
        public int TargetId { get; set; }
        public string Guestname { get; set; }
        public string Content { get; set; }
        public string ContentBbcode { get; set; }
        public DateTime Pubdate { get; set; }
        public bool? Published { get; set; }
        public bool? IsNew { get; set; }
        public string TargetTitle { get; set; }
        public string TargetLink { get; set; }
        public string Ip { get; set; }
        public bool IsHidden { get; set; }
        public int Rating { get; set; }
    }
}
