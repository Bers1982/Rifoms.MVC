using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsForum
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AccessList { get; set; }
        public string ModerList { get; set; }
        public int Ordering { get; set; }
        public bool? Published { get; set; }
        public int ParentId { get; set; }
        public int Nsleft { get; set; }
        public int Nsright { get; set; }
        public string Nsdiffer { get; set; }
        public int Nsignore { get; set; }
        public int Nslevel { get; set; }
        public string Icon { get; set; }
        public float TopicCost { get; set; }
        public int ThreadCount { get; set; }
        public int PostCount { get; set; }
        public string LastMsg { get; set; }
    }
}
