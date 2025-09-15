using Rifoms.Domain.Data.Entities.Web;
using Rifoms.Domain.Data.Models.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifoms.Domain.Data.Models
{
    /// <summary>
    /// Модель для контента 
    /// </summary>
    public class ContentModel:BaseModel
    {
        public CmsContent CurrentContent { get; set; }
        public CmsCategory CurrentCategory { get; set; }
        public List<CmsContent> CurrentContents { get; set; }
        public List<BreadCrumbModel> BreadCrumbs { get; set; }
    }
}
