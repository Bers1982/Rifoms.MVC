using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsRatingsTotal
    {
        public int Id { get; set; }
        public string Target { get; set; }
        public int ItemId { get; set; }
        public int TotalRating { get; set; }
        public int TotalVotes { get; set; }
    }
}
