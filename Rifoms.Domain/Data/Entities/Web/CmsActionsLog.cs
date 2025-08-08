using System;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsActionsLog
    {
        public int Id { get; set; }
        public int ActionId { get; set; }
        public DateTime Pubdate { get; set; }
        public int UserId { get; set; }
        public string Object { get; set; }
        public string ObjectUrl { get; set; }
        public int ObjectId { get; set; }
        public string Target { get; set; }
        public string TargetUrl { get; set; }
        public int TargetId { get; set; }
        public string Description { get; set; }
        public bool IsFriendsOnly { get; set; }
        public bool IsUsersOnly { get; set; }
    }
}
