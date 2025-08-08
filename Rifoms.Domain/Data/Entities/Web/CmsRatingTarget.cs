using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsRatingTarget
    {
        public int Id { get; set; }
        public string Target { get; set; }
        public string Component { get; set; }
        public sbyte IsUserAffect { get; set; }
        public short UserWeight { get; set; }
        public string TargetTable { get; set; }
        public string TargetTitle { get; set; }
    }
}
