using System;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsBlog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime Pubdate { get; set; }
        public string AllowWho { get; set; }
        public string ViewType { get; set; }
        public bool? Showcats { get; set; }
        public string Ownertype { get; set; }
        public bool Premod { get; set; }
        public bool Forall { get; set; }
        public string Owner { get; set; }
        public string Seolink { get; set; }
        public int Rating { get; set; }
        public int CommentsCount { get; set; }
    }
}
