using System;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsBlogAuthor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string Description { get; set; }
        public DateTime Startdate { get; set; }
    }
}
