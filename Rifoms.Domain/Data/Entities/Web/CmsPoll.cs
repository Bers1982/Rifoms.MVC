using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsPoll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Pubdate { get; set; }
        public string Answers { get; set; }
    }
}
