#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsBlogCat
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
