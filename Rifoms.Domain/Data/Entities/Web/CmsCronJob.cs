using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsCronJob
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public short JobInterval { get; set; }
        public DateTime JobRunDate { get; set; }
        public string Component { get; set; }
        public string ModelMethod { get; set; }
        public string CustomFile { get; set; }
        public bool? IsEnabled { get; set; }
        public short IsNew { get; set; }
        public string Comment { get; set; }
        public string ClassName { get; set; }
        public string ClassMethod { get; set; }
    }
}
