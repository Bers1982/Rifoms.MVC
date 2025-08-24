using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rifoms.Domain.Data.Models;
using Rifoms.Domain.Infrastructure.Interfaces;
using Rifoms.Web.Controllers.Base;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Rifoms.Web.Controllers
{
    public class HomeController : BaseController<HomeController>
    {

        public HomeController(IHttpContextAccessor httpContext, IDbService dbService,
            ILogger<HomeController> logger)
            : base(httpContext, dbService, logger)
        {
        }

        public async Task<IActionResult> AskQuestion()
        {
            var model= await Task.FromResult(new ContentModel());
            return base.View(model);
        }

        /// <summary>
        /// Метод для получения всех новостей (местных и региональных)
        /// Стартует в начале загрузки сайта
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var seolink = Request.Path.Value;

            var model = await dbService.GetAllContents(seolink);
            return base.View(model);
        }

        /// <summary>
        /// Метод для получения всех новостей ТФОМС РИ
        /// Запускается по кнопке "Все новсти ТФОМС РИ", 
        /// поиск ведется по тэгу "novosti/novosti-tfoms-ri"
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllNews()
        {
            var seolink = ExtractSEOlink(Request.Path.Value);

            var model = await dbService.GetAllNewsBySeolink(seolink);
            if (model.AllNews.Any(c => c.CategoryId == 8))
                model.NewsTitle = "Новости ТФОМС РИ";
            else
                model.NewsTitle = "Региональные новости";
            return base.View(model);
        }


        /// <summary>
        /// Метод для получения текущей новости, контента или дирекции и так далее
        /// Запускается из меню
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Content()
        {
            var seolink = Request.Path.Value;
            var id = ExtractIDFromRequest(seolink);
            var model = new ContentModel();

            if (id > 0)
                model = await dbService.GetContentByIDAsync(id);
            else
            {
                seolink = seolink.Replace("/", string.Empty).Replace(".html",string.Empty);
                var categoryId = await dbService.GetCategoryIDBySeolink(seolink);
                model = await dbService.GetContentsByCategoryIDAsync(categoryId);
                if (model.CurrentContents.Count == 0)
                {
                    model = await dbService.GetCategoryByIDAsync(categoryId);
                }
            }
            return base.View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
