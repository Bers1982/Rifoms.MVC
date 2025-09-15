using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rifoms.BurgerMenuBootstrap537.Controllers.Base;
using Rifoms.Domain.Data.Models;
using Rifoms.Domain.Data.Models.Base;
using Rifoms.Domain.Infrastructure.Interfaces;
using System.Diagnostics;

namespace Rifoms.BurgerMenuBootstrap537.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public HomeController(IHttpContextAccessor httpContext)
                    : base(httpContext)
        {
        }
        public IActionResult Index()
        {
            var model = new BaseModel();
            return View(model);
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
