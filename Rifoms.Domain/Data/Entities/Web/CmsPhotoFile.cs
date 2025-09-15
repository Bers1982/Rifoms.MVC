using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsPhotoFile
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Pubdate { get; set; }
        public string File { get; set; }
        public bool Published { get; set; }
        public int Hits { get; set; }
        public bool? Showdate { get; set; }
        public bool? Comments { get; set; }
        public int UserId { get; set; }
        public string Owner { get; set; }
        public int Rating { get; set; }
    }
}
