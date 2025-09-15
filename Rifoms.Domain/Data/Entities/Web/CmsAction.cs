#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsAction
    {
        public int Id { get; set; }
        public string Component { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsTracked { get; set; }
        public bool IsVisible { get; set; }
    }
}
