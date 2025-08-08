using System;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsBanner
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Typeimg { get; set; }
        public string Fileurl { get; set; }
        public int Hits { get; set; }
        public int Clicks { get; set; }
        public int Maxhits { get; set; }
        public int Maxuser { get; set; }
        public int UserId { get; set; }
        public DateTime? Pubdate { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public bool? Published { get; set; }
    }
}
