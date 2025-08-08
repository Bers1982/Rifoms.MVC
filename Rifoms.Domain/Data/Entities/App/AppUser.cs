using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using Rifoms.Domain.Data.Entities.Web;

namespace Rifoms.Domain.Data.Entities.App
{
    /// <summary>
    /// Таблица для авторизации Identity
    /// </summary>
    [Table("app_users")]
    [Comment("таблица для app_users")]
    public class AppUser : IdentityUser<int>
    {
        [Column("Password", TypeName = "nvarchar(30)")]
        [Comment("колонка для хранения пароля")]
        [JsonIgnore()]
        public string Password { get; set; }

        /// <summary>
        /// Таблица web_users для админов и менеджеров
        /// </summary>
        [JsonProperty(PropertyName ="User")]
        public CmsUser User { get; set; }
    }
}
