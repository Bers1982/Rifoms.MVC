using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rifoms.Domain.Data.Models;
using Rifoms.Domain.Infrastructure.Interfaces;
using Rifoms.Web_new.Controllers.Base;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace Rifoms.Web_new_new.Controllers
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
            var model = await Task.FromResult(new ContentModel());
            return base.View(model);
        }

        public async Task<IActionResult> Rss()
        {
            var seolink = Request.Path.Value;
            var model = await dbService.GetAllContents(seolink);
            var rssItems = new List<SyndicationItem>();
            if (model.News?.Count > 0)
            {
                foreach (var news in model.News)
                {
                    var rssItem = new SyndicationItem(news.Title, WebUtility.HtmlDecode(news.Content), new System.Uri($"http://www.rifoms.ru/{news.Seolink}.html"));
                    rssItems.Add(rssItem);
                }
            }
            else
            {
                foreach (var news in model.RegionNews)
                {
                    var rssItem = new SyndicationItem(news.Title, WebUtility.HtmlDecode(news.Content), new System.Uri($"http://www.rifoms.ru/{news.Seolink}.html"));
                    rssItems.Add(rssItem);
                }
            }

            var feed = new SyndicationFeed("Название сайта", "Описание сайта", new System.Uri("http://www.rifoms.ru"), rssItems);

            feed.Language = "ru-RU";
            var stream = new MemoryStream();
            using (var writer = XmlWriter.Create(stream, new XmlWriterSettings { Async = true, Indent = true }))
            {
                var formatter = new Rss20FeedFormatter(feed);
                formatter.WriteTo(writer);
                await writer.FlushAsync();
            }

            return File(stream.ToArray(), "application/xml");
            //return base.View(model);
        }

        /// <summary>
        /// Обработка ошибок
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
            int page = 1;
            var model = new AllNewsModel();
            var seolink = ExtractSEOlink(Request.Path.Value);

            if (seolink.Contains("page"))
                page = ExtractIDFromRequest(seolink);
            model = await dbService.GetAllNewsBySeolink(seolink, page);

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
        public async Task<IActionResult> Menu()
        {
            var seolink = ExtractSEOlink(Request.Path.Value);
            var model = new ContentModel();
            model = await dbService.GetContentBySeolinkAsync(seolink);
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
                //seolink = seolink.Replace("/", string.Empty).Replace(".html", string.Empty);
                seolink = ExtractSEOlink(seolink);
                var categoryId = await dbService.GetCategoryIDBySeolink(seolink);
                model = await dbService.GetContentsByCategoryIDAsync(categoryId);
                if (model.CurrentContents != null)
                {
                    if (model.CurrentContents.Count == 0)
                    {
                        model = await dbService.GetCategoryByIDAsync(categoryId);
                    }
                }
            }
            return base.View(model);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
