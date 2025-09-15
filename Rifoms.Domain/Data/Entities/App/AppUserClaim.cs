using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Rifoms.Domain.Data.Entities.App
{
    [Table("app_userclaims")]
    [Comment("таблица для app_userclaims")]
    public class AppUserClaim : IdentityUserClaim<int>
    {
    }
}
