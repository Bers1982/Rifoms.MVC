using System.Collections.Generic;
using System.Threading.Tasks;

using Rifoms.Domain.Data.Entities.Web;
using Rifoms.Domain.Data.Models;

namespace Rifoms.Domain.Infrastructure.Interfaces
{
    /// <summary>
    /// Сервис для работы с пользователями, удаление, блокирование и тд
    /// работает контекст БД, т.е AppDbContext
    /// </summary>
    public interface IDbService
    {
        /// <summary>
        /// ПОЛУЧЕНИЕ ВСЕХ ТИПОВ (МЕСТНЫХ, РЕГИОНАЛЬНЫХ) НОВОСТЕЙ
        /// </summary>
        /// <returns></returns>
        //Task<NewsModel> GetNewsModel(int? id);
        Task<NewsModel> GetAllContents(string seolink);

        /// <summary>
        /// ПОЛУЧЕНИЕ ВСЕХ BREADCRUMB's (ТО БИШЬ СУКА ХЛЕЮНЫХ КРОШЕК ДЛЯ НАВИГАЦИИ) НОВОСТЕЙ
        /// </summary>
        /// <param name="currentContentID">ID Текущей НОВОСТИ(КОНТЕНТА)</param>
        /// <param name="currentContentSeolink">SEOLINK для поиска родителя текущей НОВОСТИ(КОНТЕНТА)</param>
        /// <param name="SiteUrl">URL НАШЕГО САЙТА для HREF'ов</param>
        /// <returns></returns>
        //private Task<List<BreadCrumbModel>> GetBreadCrumbs(int currentContentID, string currentContentSeolink, string SiteUrl);


        /// <summary>
        /// ПОЛУЧЕНИЕ ID КАТЕГОРИИ НОВОСТИ по СЕОЛИНКУ
        /// </summary>
        /// <returns></returns>
        Task<int> GetCategoryIDBySeolink(string seolink);

        /// <summary>
        /// ПОЛУЧЕНИЕ ВСЕХ ТИПОВ (МЕСТНЫХ, РЕГИОНАЛЬНЫХ) НОВОСТЕЙ
        /// </summary>
        /// <returns></returns>
        Task<AllNewsModel> GetAllNewsBySeolink(string seolink);

        /// <summary>
        /// ПОЛУЧЕНИЕ ВСЕХ ТИПОВ (МЕСТНЫХ, РЕГИОНАЛЬНЫХ) НОВОСТЕЙ
        /// </summary>
        /// <returns></returns>
        Task<List<CmsContent>> GetContents(int pageSize);

        /// <summary>
        /// Получение КОНТЕНТА по ID новости
        /// </summary>
        /// <param name="seolink"></param>
        /// <returns></returns>
        Task<ContentModel> GetContentBySeolinkAsync(string seolink);

        /// <summary>
        /// Получение КОНТЕНТА по ID новости
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContentModel> GetContentByIDAsync(int id);

        /// <summary>
        /// Получение КОНТЕНТА по ID категории новости
        /// </summary>
        /// <param name="seolink"></param>
        /// <returns></returns>
        Task<ContentModel> GetContentsByCategoryIDAsync(int id);

     
        /// <summary>
        /// Получение СПИСКА (ЛИСТА, в случае, если больше одного) КОНТЕНТА по ID новости
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<CmsContent>> GetContentsByIDAsync(int id);

        ///// <summary>
        ///// Получение КОНТЕНТА по ID Категории новости
        ///// 8 - Федеральные Новости
        ///// 9 - Региональные Новости
        ///// возможно скорее всего есть и другие ID-шки
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //Task<CmsContent> GetContentByCategoryIDAsync(int id);

        ///// <summary>
        ///// Получение СПИСКА (ЛИСТА, в случае, если больше одного) КОНТЕНТА по ID Категории новости
        ///// 8 - Федеральные Новости
        ///// 9 - Региональные Новости
        ///// возможно скорее всего есть и другие ID-шки
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //Task<List<CmsContent>> GetContentsByCategoryIDAsync(int id);

        /// <summary>
        /// Получение СПИСКА (ЛИСТА, в случае, если больше одного) КОНТЕНТА по ID Категории новости
        /// 8 - Федеральные Новости
        /// 9 - Региональные Новости
        /// возможно скорее всего есть и другие ID-шки
        /// 
        /// pageSize - количество новостей на главной страничке нововстей, значение будем брать из 
        /// настроек системы, в БД будет спец. настройка
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<CmsContent>> GetContentsByCategoryIDAsync(int id, int pageSize);

        /// <summary>
        /// Получение КАТЕГОРИИ по ID Категории
        /// ИСПОЛЬЗУЮ ДЛЯ ПОЛУЧЕНИЯ ФОРМЫ И БЛАНКОВ
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContentModel> GetCategoryByIDAsync(int id);

        /// <summary>
        /// Получение ИМЕНИ ФАЙЛА ДЛЯ СКАЧИВАНИЯ по СЕОЛИНКу
        /// </summary>
        /// <param name="seolink"></param>
        /// <returns></returns>
        Task<string> GetFileNameBySeolinkAsync(string seolink);
    }
}
