#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsCommentTarget
    {
        public int Id { get; set; }
        public string Target { get; set; }
        public string Component { get; set; }
        public string Title { get; set; }
        public string TargetTable { get; set; }
        public string Subj { get; set; }
    }
}
