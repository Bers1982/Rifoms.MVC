using Rifoms.Domain.Data.Entities.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace Rifoms.Domain.Data.Entities.Web
{
    public class CmsUser:BaseUser
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Login { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Icq { get; set; }
        public DateTime Regdate { get; set; }
        public DateTime Logdate { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsLocked { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLoggedOnce { get; set; }
        public int Rating { get; set; }
        public int Points { get; set; }
        public string LastIp { get; set; }
        public string Status { get; set; }
        public DateTime StatusDate { get; set; }
        public int? InvitedBy { get; set; }
        public DateTime? Invdate { get; set; }
        public string Openid { get; set; }
    }
}
