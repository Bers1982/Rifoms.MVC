using System.ComponentModel.DataAnnotations;

namespace Rifoms.Web_new.Infrastructure.Enums
{
    public enum RoleTypeEnum
    {
        [Display(Name = "Администратор")]
        Admin,
        [Display(Name = "Менеджер")]
        Manager,
        [Display(Name = "Клиент")]
        Client
    }
}
