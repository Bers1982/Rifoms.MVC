using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUserClub
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClubId { get; set; }
        public string Role { get; set; }
        public DateTime Pubdate { get; set; }
    }
}
