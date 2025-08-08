using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUserFile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Filename { get; set; }
        public DateTime Pubdate { get; set; }
        public string AllowWho { get; set; }
        public int Filesize { get; set; }
        public int Hits { get; set; }
    }
}
