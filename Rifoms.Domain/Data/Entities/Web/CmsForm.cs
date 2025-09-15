using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsForm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Sendto { get; set; }
        public int UserId { get; set; }
        public string FormAction { get; set; }
        public string Tpl { get; set; }
        public bool OnlyFields { get; set; }
        public bool? Showtitle { get; set; }
    }
}
