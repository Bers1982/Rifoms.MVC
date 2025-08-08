using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsForumThread
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime Pubdate { get; set; }
        public int Hits { get; set; }
        public bool Closed { get; set; }
        public bool Pinned { get; set; }
        public bool IsHidden { get; set; }
        public string RelTo { get; set; }
        public int RelId { get; set; }
        public int PostCount { get; set; }
        public string LastMsg { get; set; }
    }
}
