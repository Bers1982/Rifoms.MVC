using System;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsBoardItem
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string Obtype { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Formsdata { get; set; }
        public string City { get; set; }
        public DateTime? Pubdate { get; set; }
        public int Pubdays { get; set; }
        public bool Published { get; set; }
        public string File { get; set; }
        public string MoreImages { get; set; }
        public uint Hits { get; set; }
        public bool IsVip { get; set; }
        public DateTime Vipdate { get; set; }
        public uint Ip { get; set; }
    }
}
