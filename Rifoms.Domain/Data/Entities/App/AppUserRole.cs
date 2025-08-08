using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Rifoms.Domain.Data.Entities.App
{
    [Table("app_userroles")]
    [Comment("таблица для app_userroles")]
    public class AppUserRole : IdentityUserRole<int>
    {
    }
}
