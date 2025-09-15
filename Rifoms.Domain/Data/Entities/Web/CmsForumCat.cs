using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsForumCat
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool? Published { get; set; }
        public int Ordering { get; set; }
        public string Seolink { get; set; }
    }
}
