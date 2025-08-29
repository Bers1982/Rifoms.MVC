using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Rifoms.Domain.Context;
using Rifoms.Domain.Data.Models.Base;
using Rifoms.Domain.Infrastructure.Interfaces;

namespace Rifoms.Web.Controllers.Base
{
    /// <summary>
    /// Базовый контроллер для контроллеров
    /// </summary>
    public class BaseController<T> : Controller where T : class
    {

        #region public ReadOnly Objects
        public readonly IWebHostEnvironment webHostEnvironment;
        public readonly IConfiguration configuration;
        public readonly RifomsDbContext dbContext;
        public readonly IHttpContextAccessor httpContext;
        public readonly IDbService dbService;
        public readonly IRazorRenderService razorRenderService;
        public readonly BaseModel baseModel;
        //public readonly IEmailSender emailSender;
        public readonly IMailService mailService;
        public readonly ILogger<T> logger;
        #endregion

        #region Public Variables         

        /// <summary>
        /// Если ID КОНТЕНТА ИНФОРМАЦИИ существует ?
        /// </summary>
        public bool IdExist { get; set; }
        //public string WebSiteUrl { get { return Location.AbsoluteUri; } }

        #endregion

        #region Private VAriables
        private Uri Location { get; set; }

        #endregion

        /// <summary>
        /// Custom page model for adding many services used in Razaor Pages Model
        /// </summary>
        /// <param name="_context"></param>
        public BaseController(params object[] list)
        {
            baseModel = new BaseModel();
            foreach (var item in list)
            {
                if (item is IWebHostEnvironment _webHostEnvironment)
                    webHostEnvironment = _webHostEnvironment;
                if (item is RifomsDbContext _dbContext)
                    dbContext = _dbContext;
                if (item is IConfiguration _configuration)
                    configuration = _configuration;
                if (item is IHttpContextAccessor _httpContext)
                    httpContext = _httpContext;
                if (item is IDbService _dbService)
                    dbService = _dbService;
                if (item is IRazorRenderService _razorRenderService)
                    razorRenderService = _razorRenderService;
                if (item is IMailService _mailService)
                    mailService = _mailService;
                if (item is ILogger<T> _logger)
                    logger = _logger;
            }

            Location = new Uri($"{httpContext.HttpContext.Request.Scheme}://{httpContext.HttpContext.Request.Host}");
            baseModel.SiteUrl = Location.AbsoluteUri;
        }

        /// <summary>
        /// REPTURN SEOLINK AFTER LAST LEADER SYMBOL "/" FROM REQUEST PATH VALUE
        /// </summary>
        /// <param name="seolink"></param>
        /// <returns></returns>
        public string ExtractSEOlink(string seolink)
        {
            if (seolink != null)
            {
                seolink = seolink.Replace(".html", "");
                int lastIndex = seolink.LastIndexOf("/");
                seolink = seolink.Substring(lastIndex + 1);
            }
            return seolink;
        }

        /// <summary>
        /// RETURN ID FROM REQUEST PATH VALUE
        /// </summary>
        /// <param name="seolink"></param>
        /// <returns></returns>
        public int ExtractIDFromRequest(string seolink)
        {
            seolink = seolink.Substring(1, seolink.Length - 1).Replace(".html", "");
            string idValue = seolink.Split("/")[0];
            if (int.TryParse(idValue, out int id))
                id = Convert.ToInt32(idValue);
            return id;
        }


        /// <summary>
        /// Получение списка ошибок для данной модели
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public string GetModelErrors(ModelStateDictionary modelState)
        {
            var errorsModel = modelState.Select(x => x.Value.Errors)
                                                      .Where(y => y.Count > 0)
                                                      .ToList();
            var modelErrors = errorsModel.SelectMany(c => c).ToList();
            modelErrors.Select(c => c.ErrorMessage).ToArray();
            var errors = String.Empty;
            errors = String.Join("\n", modelErrors.Select(c => c.ErrorMessage));
            return errors.ToString();
        }

        //public int? ToNullableInt(this string s)
        //{
        //    int i;
        //    if (int.TryParse(s, out i)) return i;
        //    return null;
        //}
    }
}
