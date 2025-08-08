using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsGeoCity
    {
        public uint Id { get; set; }
        public uint CountryId { get; set; }
        public uint RegionId { get; set; }
        public string Name { get; set; }
    }
}
