using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using KellermanSoftware.CompareNetObjects;

namespace Rifoms.Web.Infrastructure.Enums
{
    /// <summary>
    /// Перечисление для измененных полей объектов таких Заявка (Zayavka), Услуги Заявки (Nominations), Клиенты (Clients), 
    /// Менеджеры (Managers) 
    /// </summary>
    public enum ChangeZayavkaEnum
    {
        //Список перечисления для заявок
        UserId,
        Invoice,
        Name,
        CreationDate,
        Country,
        Kurs,
        NomerMashini,
        Comment,
        ChooseFiles,
        StatusZayavki,
        ChangeDate,
        Transport,
        Gtd,
        Oformleniye,
        RowStatus
    }

    public static class ChangeZayavkaEnumExtensions
    {
        /// <summary>
        /// Получить значения перечисления для данного типа
        /// </summary>
        /// <param name="c">Объект Difference, объект различие</param>
        /// <returns></returns>

        public static string GetEnumValue(Difference c)
        {
            return GetString((ChangeZayavkaEnum)Enum.Parse(typeof(ChangeZayavkaEnum), c.PropertyName));
        }

        private static string GetString(this ChangeZayavkaEnum me)
        {
            switch (me)
            {
                case ChangeZayavkaEnum.UserId: return "ID Менеджера";
                case ChangeZayavkaEnum.Invoice: return "Счёт";
                case ChangeZayavkaEnum.Name: return "Название заявки";
                case ChangeZayavkaEnum.CreationDate: return "Дата создания";
                case ChangeZayavkaEnum.Kurs: return "Курс";
                case ChangeZayavkaEnum.Country: return "Страна";
                case ChangeZayavkaEnum.StatusZayavki: return "Статус заявки";
                case ChangeZayavkaEnum.Comment: return "Комментарий";
                case ChangeZayavkaEnum.ChooseFiles: return "Выбор файлов";
                case ChangeZayavkaEnum.NomerMashini: return "Номер машины";
                case ChangeZayavkaEnum.Transport: return "Транспорт";
                case ChangeZayavkaEnum.Gtd: return "Поле ГТД";
                case ChangeZayavkaEnum.ChangeDate: return "Дата статуса заявки";
                case ChangeZayavkaEnum.Oformleniye: return "Оформление";
                case ChangeZayavkaEnum.RowStatus: return "Статус записи в БД";

                default: return String.Empty;
            }
        }
    }
}
