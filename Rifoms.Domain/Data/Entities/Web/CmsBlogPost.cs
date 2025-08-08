using System;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsBlogPost
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CatId { get; set; }
        public int BlogId { get; set; }
        public DateTime Pubdate { get; set; }
        public string Title { get; set; }
        public string Feel { get; set; }
        public string Music { get; set; }
        public string Content { get; set; }
        public string ContentHtml { get; set; }
        public string AllowWho { get; set; }
        public int EditTimes { get; set; }
        public DateTime EditDate { get; set; }
        public bool? Published { get; set; }
        public string Seolink { get; set; }
        public bool? Comments { get; set; }
        public int CommentsCount { get; set; }
        public int Rating { get; set; }
    }
}
