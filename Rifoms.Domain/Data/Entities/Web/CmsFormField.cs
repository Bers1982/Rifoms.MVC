using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsFormField
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Ordering { get; set; }
        public string Kind { get; set; }
        public int Mustbe { get; set; }
        public string Config { get; set; }
    }
}
