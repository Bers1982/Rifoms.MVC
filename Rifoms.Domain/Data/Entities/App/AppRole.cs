using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Rifoms.Domain.Data.Entities.App
{
    [Table("app_roles")]
    [Comment("таблица для app_roles")]
    public class AppRole : IdentityRole<int>
    {
    }
}
