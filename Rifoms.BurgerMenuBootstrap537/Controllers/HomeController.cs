using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rifoms.BurgerMenuBootstrap537.Controllers.Base;
using Rifoms.Domain.Data.Models;
using Rifoms.Domain.Infrastructure.Interfaces;
using System.Diagnostics;

namespace Rifoms.BurgerMenuBootstrap537.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public HomeController(IHttpContextAccessor httpContext, IDbService dbService,
                    ILogger<HomeController> logger)
                    : base(httpContext, dbService, logger)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
