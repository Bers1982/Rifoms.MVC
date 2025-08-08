using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

namespace Rifoms.Domain.Infrastructure.Helper
{
    /// <summary>
    /// Модель для отправки писем
    /// с влоэжениямми
    /// </summary>
    public class MailRequest
    {
        /// <summary>
        /// Почта, кому нужно отправить письмецо (обязательно)
        /// </summary>
        [Required(ErrorMessage ="Поле 'Кому' должно быть заполнено :((")]
        [EmailAddress(ErrorMessage ="Email должен быть корректный :((")]
        [Display(Name ="Почтовый ящик")]
        public string ToEmail { get; set; }

        /// <summary>
        /// Тема письмеца (обязательно)
        /// </summary>
        [Required(ErrorMessage = "Поле 'Тема' должно быть заполнено :((")]
        public string Subject { get; set; }

        /// <summary>
        /// Тело письмеца (обязательно)
        /// </summary>
        [Required(ErrorMessage = "Поле 'Содержимое письма' должно быть заполнено :((")]
        public string Body { get; set; }

        /// <summary>
        /// Список файлов для вложений, скорее всего не буду использовать
        /// </summary>
        public List<IFormFile> Attachments { get; set; }
    }
}
