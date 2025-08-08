using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsForumPoll
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Answers { get; set; }
        public string Options { get; set; }
        public DateTime Enddate { get; set; }
    }
}
