using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUcDiscount
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CatId { get; set; }
        public sbyte Sign { get; set; }
        public float Value { get; set; }
        public string Unit { get; set; }
        public int IfLimit { get; set; }
    }
}
