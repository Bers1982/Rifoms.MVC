using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Rifoms.Domain.Data.Entities.App
{
    [Table("app_usertokens")]
    [Comment("таблица для app_usertokens")]
    public class AppUserToken : IdentityUserToken<int>
    {
    }
}
