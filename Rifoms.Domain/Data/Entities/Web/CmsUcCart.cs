using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUcCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SessionId { get; set; }
        public int ItemId { get; set; }
        public DateTime Pubdate { get; set; }
        public int Itemscount { get; set; }
    }
}
