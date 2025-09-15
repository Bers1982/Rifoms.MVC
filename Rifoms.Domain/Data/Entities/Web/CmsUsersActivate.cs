using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUsersActivate
    {
        public int Id { get; set; }
        public DateTime Pubdate { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; }
    }
}
