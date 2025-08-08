using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsRating
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Points { get; set; }
        public string Ip { get; set; }
        public string Target { get; set; }
        public int UserId { get; set; }
        public DateTime Pubdate { get; set; }
    }
}
