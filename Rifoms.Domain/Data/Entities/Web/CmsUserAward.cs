using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUserAward
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Pubdate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Imageurl { get; set; }
        public int FromId { get; set; }
        public int AwardId { get; set; }
    }
}
