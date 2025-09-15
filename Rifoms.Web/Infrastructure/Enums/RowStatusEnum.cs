using System;

namespace Rifoms.Web.Infrastructure.Enums
{
    /// <summary>
    /// Перечисление для таблицы RowStatus, обьясняющая какая запись добавлена или 
    /// заблокирована, удалена, редактирована и т.д
    /// значения будут пополняться статуса
    /// </summary>
    public enum RowStatusEnum
    {
        Created,
        Blocked,
        Deleted,
        UnBlocked,
        Edited
    }
    public static class RowStatusEnumExtensions
    {
        public static string GetString(this RowStatusEnum me)
        {
            switch (me)
            {
                case RowStatusEnum.Created: return "Создан";
                case RowStatusEnum.Blocked: return "Заблокирован";
                case RowStatusEnum.Deleted: return "Удален";
                case RowStatusEnum.UnBlocked: return "Разблокирован";
                case RowStatusEnum.Edited: return "Редактирован";

                default: return String.Empty;
            }
        }
    }
}
