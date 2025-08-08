using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Rifoms.Domain.Context;
using Rifoms.Domain.Data.Entities.Web;
using Rifoms.Domain.Data.Models;
using Rifoms.Domain.Infrastructure.Interfaces;

namespace Rifoms.Domain.Infrastructure.Services
{
    /// <summary>
    /// Сервис для работы с пользователями, удаление, блокирование и тд
    /// работает контекст БД, т.е AppDbContext
    /// </summary>
    public class DbService : IDbService
    {
        #region PRIVATE and PUBLIC PROPERTIES 
        //фабрика для DBCONTEXT
        private readonly Func<RifomsDbContext> dbFactory;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContext;
        private Uri Location;
        private string SiteUrl;

        //public bool IsServer;
        #endregion

        #region CONSTRUCTOR
        public DbService(Func<RifomsDbContext> _dbFactory,
            IConfiguration _configuration, IHttpContextAccessor _httpContext)
        {
            dbFactory = _dbFactory;
            configuration = _configuration;
            httpContext = _httpContext;
            Location = new Uri($"{httpContext.HttpContext.Request.Scheme}://{httpContext.HttpContext.Request.Host}");
            SiteUrl = Location.AbsoluteUri.Remove(Location.AbsoluteUri.Length - 1, 1);
        }


        #endregion
        #region METHODS TO GET DATA's from DATABASE

        public async Task<NewsModel> GetAllContents(string seolink)
        {
            var model = new NewsModel { SiteUrl = SiteUrl };
            int pageSize = 10;

            using var dbContext = dbFactory();

            if (seolink == "/")
            {
                model.IdExist = false;

                model.News = await dbContext.CmsContents
                 .Where(c => c.CategoryId == 8)
                 .OrderByDescending(c => c.Pubdate)
                 .Take(pageSize)
                 .ToListAsync();

                model.RegionNews = await dbContext.CmsContents
                   .Where(c => c.CategoryId == 9)
                   .OrderByDescending(c => c.Pubdate)
                   .Take(pageSize)
                   .ToListAsync();
            }
            return model;
        }

        public async Task<AllNewsModel> GetAllNewsBySeolink(string seolink)
        {
            var model = new AllNewsModel { SiteUrl = SiteUrl };

            using var dbContext = dbFactory();
            if (seolink.Contains("novosti-tfoms-ri"))
            {
                model.AllNews = await dbContext.CmsContents
                     //.Where(c => c.Seolink.Contains(seolink) && c.CategoryId == 8)
                     .Where(c => c.CategoryId == 8)
                     .OrderByDescending(c => c.Pubdate)
                     .ToListAsync();
            }
            else
            {
                model.AllNews = await dbContext.CmsContents
                    //.Where(c => c.Seolink.Contains(seolink) && c.CategoryId == 9)
                    .Where(c => c.CategoryId == 9)
                    .OrderByDescending(c => c.Pubdate)
                    .ToListAsync();
            }

            return model;
        }

        public async Task<List<CmsContent>> GetContents(int pageSize)
        {
            using var dbContext = dbFactory();
            return await dbContext.CmsContents
                                //.Where(c => c.CategoryId == 8 || c.CategoryId == 9)
                                .Where(c => c.CategoryId == 8 || c.CategoryId == 9)

                .OrderByDescending(c => c.Pubdate)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<CmsContent> GetContentBySeolinkAsync(string seolink)
        {
            using var dbContext = dbFactory();
            return await dbContext.CmsContents
                .Where(c => c.Seolink == seolink)
                .SingleOrDefaultAsync();
        }

        public async Task<ContentModel> GetContentByIDAsync(int id)
        {
            using var dbContext = dbFactory();
            var model = new ContentModel { SiteUrl = SiteUrl };
            if (id > 0)
            {
                model.CurrentContent = await dbContext.CmsContents
                   .Where(c => c.Id == id)
                   .SingleOrDefaultAsync();
                model.CurrentContents = null;
                if (model.CurrentContent != null)
                {
                    if (model.CurrentContent.CategoryId == 1 || model.CurrentContent.CategoryId == 6)
                    {
                        model.BreadCrumbs = new List<BreadCrumbModel>();
                        model.BreadCrumbs = await GetBreadCrumbs(model.CurrentContent.Id, model.CurrentContent.Title, model.CurrentContent.Seolink, model.SiteUrl, "mainmenu");
                    }
                }
            }

            return model;
        }

        /// <summary>
        /// ПОЛУЧЕНИЕ ВСЕХ BREADCRUMB's (ТО БИШЬ СУКА ХЛЕБНЫХ КРОШЕК ДЛЯ НАВИГАЦИИ) НОВОСТЕЙ
        /// </summary>
        /// <param name="currentContentID">ID Текущей НОВОСТИ(КОНТЕНТА)</param>
        /// <param name="currentContentSeolink">SEOLINK для поиска родителя текущей НОВОСТИ(КОНТЕНТА)</param>
        /// <param name="SiteUrl">URL НАШЕГО САЙТА для HREF'ов</param>
        /// <returns></returns>
        private async Task<List<BreadCrumbModel>> GetBreadCrumbs(int id, string title, string seolink, string siteUrl, string menu = "mainmenu")
        {
            using var dbContext = dbFactory();
            var model = new List<BreadCrumbModel>();
            var breadCrumb = new BreadCrumbModel { SiteUrl = SiteUrl };

            var parentID = await dbContext.CmsMenus
              .Where(c => c.Link.Contains($"/{seolink}"))
              .Select(c => c.ParentId)
              .FirstOrDefaultAsync();

            breadCrumb = await dbContext.CmsMenus
                .Where(c => c.Id == parentID)
                .Select(c => new BreadCrumbModel { Id = Convert.ToInt32(c.Linkid), Menu = c.Menu, Title = c.Title, SiteUrl = siteUrl, SeoLink = c.Link })
                .SingleOrDefaultAsync();

            if (breadCrumb != null)
            {
                if (breadCrumb.SeoLink.Contains(".html"))
                    breadCrumb.SeoLink = breadCrumb.SeoLink.Replace(".html", "");

                if (breadCrumb.SeoLink.StartsWith("/"))
                    breadCrumb.SeoLink = breadCrumb.SeoLink.Remove(0, 1);

                model.Add(new BreadCrumbModel { Id = 0, Title = "Главная", SiteUrl = siteUrl, SeoLink = "/" });
                if (breadCrumb.Menu != "root")
                    model.Add(breadCrumb);
                model.Add(new BreadCrumbModel { Id = id, Title = title, SiteUrl = siteUrl, SeoLink = seolink });
            }

            return model;
        }

        public async Task<List<CmsContent>> GetContentsByIDAsync(int id)
        {
            using var dbContext = dbFactory();
            return await dbContext.CmsContents
                .Where(c => c.Id == id)
                .ToListAsync();
        }

        public async Task<CmsContent> GetContentByCategoryIDAsync(int id)
        {
            using var dbContext = dbFactory();
            return await dbContext.CmsContents
                .Where(c => c.CategoryId == id)
                .OrderByDescending(c => c.Pubdate)
                .Take(10)
                .SingleOrDefaultAsync();
        }

        public async Task<List<CmsContent>> GetContentsByCategoryIDAsync(int id, int pageSize)
        {
            using var dbContext = dbFactory();
            return await dbContext.CmsContents
                .Where(c => c.CategoryId == id)
                .OrderByDescending(c => c.Pubdate)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<CmsCategory> GetCategoryByIDAsync(int id)
        {
            using var dbContext = dbFactory();
            return await dbContext.CmsCategories
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<int> GetCategoryIDBySeolink(string seolink)
        {
            using var dbContext = dbFactory();
            return await dbContext.CmsCategories
                .Where(c => c.Seolink == seolink)
                .Select(c => c.Id).SingleOrDefaultAsync();
        }

        public async Task<ContentModel> GetContentsByCategoryIDAsync(int id)
        {
            using var dbContext = dbFactory();
            var model = new ContentModel { SiteUrl = SiteUrl };
            if (id > 0)
            {
                model.CurrentContents = await dbContext.CmsContents
                   .Where(c => c.CategoryId == id)
                   .ToListAsync();
                model.CurrentContent = null;
                if (model.CurrentContent != null)
                {
                    if (model.CurrentContent.CategoryId == 1 || model.CurrentContent.CategoryId == 6)
                    {
                        model.BreadCrumbs = new List<BreadCrumbModel>();
                        model.BreadCrumbs = await GetBreadCrumbs(model.CurrentContent.Id, model.CurrentContent.Title, model.CurrentContent.Seolink, model.SiteUrl, "mainmenu");
                    }
                }
            }

            return model;
        }

        #endregion
    }
}

