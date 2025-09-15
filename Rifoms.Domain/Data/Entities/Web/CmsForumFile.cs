using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsForumFile
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Filename { get; set; }
        public int Filesize { get; set; }
        public int Hits { get; set; }
        public DateTime Pubdate { get; set; }
    }
}
