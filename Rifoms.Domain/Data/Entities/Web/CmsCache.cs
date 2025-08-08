using System;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsCache
    {
        public int Id { get; set; }
        public string Target { get; set; }
        public string TargetId { get; set; }
        public DateTime Cachedate { get; set; }
        public string Cachefile { get; set; }
    }
}
