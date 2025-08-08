using System;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsClub
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Imageurl { get; set; }
        public DateTime Pubdate { get; set; }
        public string Clubtype { get; set; }
        public bool? Published { get; set; }
        public int Maxsize { get; set; }
        public bool? EnabledBlogs { get; set; }
        public bool? EnabledPhotos { get; set; }
        public int Rating { get; set; }
        public int MembersCount { get; set; }
        public bool PhotoPremod { get; set; }
        public bool BlogPremod { get; set; }
        public int BlogMinKarma { get; set; }
        public int PhotoMinKarma { get; set; }
        public int AlbumMinKarma { get; set; }
        public int JoinMinKarma { get; set; }
        public int JoinKarmaLimit { get; set; }
        public int CreateKarma { get; set; }
        public bool IsVip { get; set; }
        public float JoinCost { get; set; }
    }
}
