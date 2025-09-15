using System;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsBannerHit
    {
        public int Id { get; set; }
        public int BannerId { get; set; }
        public string Ip { get; set; }
        public DateTime Pubdate { get; set; }
    }
}
