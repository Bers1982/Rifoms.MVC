using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUserGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public bool IsAdmin { get; set; }
        public string Access { get; set; }
    }
}
