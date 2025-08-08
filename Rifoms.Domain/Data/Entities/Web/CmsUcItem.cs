using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUcItem
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public DateTime Pubdate { get; set; }
        public bool? Published { get; set; }
        public string Imageurl { get; set; }
        public string Fieldsdata { get; set; }
        public int Hits { get; set; }
        public bool IsComments { get; set; }
        public string Tags { get; set; }
        public float Rating { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKeys { get; set; }
        public float Price { get; set; }
        public int Canmany { get; set; }
        public int UserId { get; set; }
        public int OnModerate { get; set; }
    }
}
