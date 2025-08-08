using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsSearch
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? Pubdate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Place { get; set; }
        public string Placelink { get; set; }
    }
}
