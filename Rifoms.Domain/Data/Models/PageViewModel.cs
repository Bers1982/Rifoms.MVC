using Rifoms.Domain.Data.Models.Base;

using System;

namespace Rifoms.Domain.Data.Models
{
    /// <summary>
    /// PageViewModel, класс который будет содержать всю информацию о пагинации   
    /// </summary>
    public class PageViewModel: BaseModel
    {
        /// <summary>
        /// Номер текущей страницы в свойстве PageNumber
        /// </summary>
        public int PageNumber { get; private set; }

        /// <summary>
        /// Общее количество страниц в свойстве TotalPages
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// ПРизнак сущестования ДО текущей страницы,
        /// есть ли еще какие-нибудь страницы
        /// </summary>
        public bool HasPreviousPage => PageNumber > 1;

        /// <summary>
        /// ПРизнак сущестования ПОСЛЕ текущей страницы,
        /// есть ли еще какие-нибудь страницы
        /// </summary>
        public bool HasNextPage => PageNumber < TotalPages;
        public PageViewModel(int count,int pageNumber,int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
