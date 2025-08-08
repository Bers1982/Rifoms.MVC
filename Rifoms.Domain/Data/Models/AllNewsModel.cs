using System.Collections.Generic;

using Rifoms.Domain.Data.Entities.Web;
using Rifoms.Domain.Data.Models.Base;

namespace Rifoms.Domain.Data.Models
{
    /// <summary>
    /// Модель для всех типов новостей (всего листа и конткретно одной новости),
    /// региональных и местных
    /// </summary>
    public class AllNewsModel:BaseModel
    {
        public string NewsTitle;
        public List<CmsContent> AllNews = new List<CmsContent>();
    }
}
