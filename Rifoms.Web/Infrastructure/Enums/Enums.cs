using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rifoms.Web.Infrastructure.Enums
{
    /// <summary>
    /// Перечисление для типов,
    /// </summary>
    public enum Enums
    {
        /// <summary>
        /// Статус 'Выдано со склада в Москве' специально для тех услуг, которые завершили по галочке в интерфейсе услуги
        /// </summary>
        ReleasedFromMoscow,

        #region Для значений всяких строк, когда нет конкретного значения из БД
        /// <summary>
        /// Значение перечисления 'Неизвестен' в мужском роде
        /// </summary>
        UnknownMale,

        /// <summary>
        /// Значение перечисления 'Неизвестна' в женском роде
        /// </summary>
        UnknownFemale,

        /// <summary>
        /// Значение перечисления 'Не указан' в мужском роде
        /// </summary>
        NotIndicatedMale,

        /// <summary>
        /// Значение перечисления 'Не указана' в женском роде
        /// </summary
        NotIndicatedFemale,
        #endregion

        #region Для значений всякизх упаковок
        /// <summary>
        /// Значение 'Рулон' для упаковки
        /// </summary>
        Roll,

        /// <summary>
        /// Значение 'Коробка' для упаковки
        /// </summary>
        Case,

        /// <summary>
        /// Значение 'Мешок' для упаковки
        /// </summary>
        Sack,

        /// <summary>
        /// Значение 'Паллет' для упаковки
        /// </summary>
        Pallets,

        /// <summary>
        /// Значение 'Пакет' для упаковки
        /// </summary>
        Packet,

        /// <summary>
        /// Значение 'Место' для упаковки
        /// </summary>
        Place,

        /// <summary>
        /// Значение 'Ящик' для упаковки
        /// </summary>
        Box,

        /// <summary>
        /// Значение 'Бочка' для упаковки
        /// </summary>
        Cask,

        /// <summary>
        /// Значение 'Неизвестная упаковка' для упаковки
        /// </summary>
        UnknownPackage
        #endregion

    }

    public static class EnumsExtensions
    {
        public static string GetString(this Enums me)
        {
            switch (me)
            {
                case Enums.ReleasedFromMoscow: return "Выдано со склада в Москве";

                #region Для различных значений
                case Enums.UnknownMale: return "Неизвестен";
                case Enums.UnknownFemale: return "Неизвестна";
                case Enums.NotIndicatedMale: return "Не указан";
                case Enums.NotIndicatedFemale: return "Не указана";
                #endregion

                #region Для значений упаковок
                case Enums.Roll: return "Рулон";
                case Enums.Case: return "Коробка";
                case Enums.Sack: return "Мешок";
                case Enums.Pallets: return "Паллет";
                case Enums.Packet: return "Пакет";
                case Enums.Place: return "Место";
                case Enums.Box: return "Ящик";
                case Enums.Cask: return "Бочка";
                case Enums.UnknownPackage: return "Неизвестная упаковка";
                #endregion

                default: return String.Empty;
            }
        }
    }
}
