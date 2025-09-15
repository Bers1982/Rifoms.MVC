using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsForumPost
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public bool Pinned { get; set; }
        public DateTime Pubdate { get; set; }
        public DateTime Editdate { get; set; }
        public int Edittimes { get; set; }
        public int Rating { get; set; }
        public int AttachCount { get; set; }
        public string Content { get; set; }
        public string ContentHtml { get; set; }
    }
}
