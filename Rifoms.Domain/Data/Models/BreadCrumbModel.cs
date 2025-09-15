using Rifoms.Domain.Data.Models.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifoms.Domain.Data.Models
{
    /// <summary>
    /// BreadCrumb MODEL
    /// </summary>
    public class BreadCrumbModel:BaseModel
    {
        /// <summary>
        /// ID BreadCrumb MODEL
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// MENU BreadCrumb's
        /// </summary>
        public string Menu { get; set; }
        /// <summary>
        /// TITLE BreaCrumb MODEL
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// BreadCrumb'S SEOLINK'a
        /// </summary>
        public string SeoLink { get; set; }

    }
}
