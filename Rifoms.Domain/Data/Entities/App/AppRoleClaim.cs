using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Rifoms.Domain.Data.Entities.App
{
    [Table("app_roleclaims")]
    [Comment("таблица для app_roleclaims")]
    public class AppRoleClaim : IdentityRoleClaim<int>
    { 
    }    
}
