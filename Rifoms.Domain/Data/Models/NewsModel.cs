using Rifoms.Domain.Data.Entities.Web;
using Rifoms.Domain.Data.Models.Base;

using System.Collections.Generic;

namespace Rifoms.Domain.Data.Models
{
    /// <summary>
    /// Модель для всех типов новостей (всего листа и конткретно одной новости),
    /// региональных и местных
    /// </summary>
    public class NewsModel: BaseModel
    {        
        /// <summary>
        /// Новости ТФОМС РИ
        /// </summary>
        public List<CmsContent> News = new List<CmsContent>();
        /// <summary>
        /// Региональные новости
        /// </summary>
        public List<CmsContent> RegionNews = new List<CmsContent>();

        /// <summary>
        /// Текущая новость, контент и так далее и тому подобное
        /// </summary>
        public ContentModel CurrentContent = new ContentModel();
        public bool IdExist;
    }
}
