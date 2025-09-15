using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsGeoCountry
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Alpha2 { get; set; }
        public string Alpha3 { get; set; }
        public int Iso { get; set; }
        public int Ordering { get; set; }
    }
}
