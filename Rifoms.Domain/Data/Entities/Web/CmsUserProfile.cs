using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public partial class CmsUserProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public bool Showmail { get; set; }
        public bool Showbirth { get; set; }
        public bool Showicq { get; set; }
        public int Karma { get; set; }
        public string Imageurl { get; set; }
        public string AllowWho { get; set; }
        public string Signature { get; set; }
        public string SignatureHtml { get; set; }
        public string Gender { get; set; }
        public string Formsdata { get; set; }
        public int EmailNewmsg { get; set; }
        public string CmSubscribe { get; set; }
        public string Stats { get; set; }
    }
}
