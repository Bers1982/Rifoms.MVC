using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUcRating
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Points { get; set; }
        public string Ip { get; set; }
    }
}
