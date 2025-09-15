using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUserWall
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AuthorId { get; set; }
        public DateTime Pubdate { get; set; }
        public string Content { get; set; }
        public string Usertype { get; set; }
    }
}
