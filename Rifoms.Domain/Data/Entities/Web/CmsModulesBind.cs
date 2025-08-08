using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsModulesBind
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int MenuId { get; set; }
        public string Position { get; set; }
    }
}
