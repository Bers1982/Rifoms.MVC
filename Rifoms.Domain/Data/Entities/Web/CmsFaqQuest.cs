using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsFaqQuest
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public DateTime Pubdate { get; set; }
        public bool Published { get; set; }
        public string Quest { get; set; }
        public string Answer { get; set; }
        public int UserId { get; set; }
        public int AnsweruserId { get; set; }
        public DateTime Answerdate { get; set; }
        public int Hits { get; set; }
    }
}
