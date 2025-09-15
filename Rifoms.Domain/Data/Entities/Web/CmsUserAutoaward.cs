using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUserAutoaward
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Imageurl { get; set; }
        public int PComment { get; set; }
        public int PBlog { get; set; }
        public int PForum { get; set; }
        public int PPhoto { get; set; }
        public int? PPrivphoto { get; set; }
        public int PContent { get; set; }
        public int PKarma { get; set; }
        public bool? Published { get; set; }
    }
}
