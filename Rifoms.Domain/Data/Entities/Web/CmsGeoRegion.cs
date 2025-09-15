using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsGeoRegion
    {
        public uint Id { get; set; }
        public uint CountryId { get; set; }
        public string Name { get; set; }
    }
}
