using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifoms.Domain.Data.Models.Base
{
    /// <summary>
    /// Базовая модель для всех моделей
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// ЛОКАЛЬНЫЙ URL НАШЕГО ВЕБ-ПРИЛОЖЕНИЯ
        /// </summary>
        public string SiteUrl { get; set; }
    }
}
