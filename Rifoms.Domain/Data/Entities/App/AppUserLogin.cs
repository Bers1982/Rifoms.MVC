using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Rifoms.Domain.Data.Entities.App
{
    [Table("app_userlogins")]
    [Comment("таблица для app_userlogins")]
    public class AppUserLogin : IdentityUserLogin<int>
    {
    }
}
