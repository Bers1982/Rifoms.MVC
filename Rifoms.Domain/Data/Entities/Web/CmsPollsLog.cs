using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsPollsLog
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        public string Answer { get; set; }
        public int UserId { get; set; }
        public string Ip { get; set; }
    }
}
