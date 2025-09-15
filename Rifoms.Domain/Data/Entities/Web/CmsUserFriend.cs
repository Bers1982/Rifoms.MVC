using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUserFriend
    {
        public int Id { get; set; }
        public int ToId { get; set; }
        public int FromId { get; set; }
        public DateTime Logdate { get; set; }
        public bool IsAccepted { get; set; }
    }
}
