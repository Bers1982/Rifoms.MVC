using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using KellermanSoftware.CompareNetObjects;

namespace Rifoms.Web.Infrastructure.Enums
{
    public enum ChangeNominationEnum
    {
        //Список перечисления для услуг заявок
        UserId,
        IsChecked,
        ClientId,
        CustomerId,
        UpdakovkaId,
        Status,
        Nomination,
        Mesto,
        Ves,
        StavkaUE,
        SummaUE,
        Comment,
        Fves,
        M3,
        EndDate,
        SkladDate,
        Deck,
        Pack,
        RowStatus
    }

    public static class ChangeNominationEnumExtensions
    {
        /// <summary>
        /// Получить значения перечисления для данного типа
        /// </summary>
        /// <param name="c">Объект Difference, объект различие</param>
        /// <returns></returns>

        public static string GetEnumValue(Difference c)
        {
            return GetString((ChangeNominationEnum)Enum.Parse(typeof(ChangeNominationEnum), c.PropertyName));
        }

        private static string GetString(this ChangeNominationEnum me)
        {
            switch (me)
            {
                case ChangeNominationEnum.UserId: return "ID Менеджера";
                case ChangeNominationEnum.IsChecked: return "Отмечен";
                case ChangeNominationEnum.ClientId: return "Клиент";
                case ChangeNominationEnum.CustomerId: return "Поставщик";
                case ChangeNominationEnum.UpdakovkaId: return "Упаковка";
                case ChangeNominationEnum.Status: return "Статус";
                case ChangeNominationEnum.Nomination: return "Наименование";
                case ChangeNominationEnum.Mesto: return "Место";
                case ChangeNominationEnum.Ves: return "Вес";
                case ChangeNominationEnum.StavkaUE: return "Ставка, $";
                case ChangeNominationEnum.SummaUE: return "Сумма, $";
                case ChangeNominationEnum.Comment: return "Комментарий";
                case ChangeNominationEnum.Fves: return "Ф, вес";
                case ChangeNominationEnum.M3: return "М3";
                case ChangeNominationEnum.EndDate: return "Дата завершения заявки";
                case ChangeNominationEnum.SkladDate: return "Дата поставки на склад";
                case ChangeNominationEnum.Deck: return "Deck";
                case ChangeNominationEnum.Pack: return "Pack";
                case ChangeNominationEnum.RowStatus: return "Статус записи в БД";

                default: return String.Empty;
            }
        }
    }
}

