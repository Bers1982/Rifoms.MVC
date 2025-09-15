using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Rifoms.Domain.Data.Models;
using Rifoms.Domain.Data.Models.Base;
using Rifoms.Domain.Infrastructure.Interfaces;

using Rifoms.Web_new.Controllers.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rifoms.Web_new.Controllers
{
    //[Authorize(Roles = "admin,manager", Policy = "ZayavkaPolicy")]

    public class AuthController : BaseController<AuthController>
    {

        public AuthController(IHttpContextAccessor httpContext, IDbService dbService,
            ILogger<AuthController> logger)
            : base(httpContext, dbService, logger)
        {
        }

        public async Task<IActionResult> Login()
        {
            var model = new LoginModel();

            return View(await Task.FromResult(model));
        }

        public async Task<IActionResult> AccessDenied()
        {
            var model = new AccessDeniedModel();

            return View(await Task.FromResult(model));
        }

        public async Task<IActionResult> Test()
        {
            var model = new BaseModel();

            return View(await Task.FromResult(model));
        }
        public async Task<IActionResult> Editor()
        {
            var model = new BaseModel();

            return View(await Task.FromResult(model));
        }


        public async Task<IActionResult> Forgot()
        {
            var model = new ForgotModel();

            return View(await Task.FromResult(model));
        }

        public async Task<IActionResult> Register()
        {
            var model = new RegisterModel();

            return View(await Task.FromResult(model));
        }
    }
}
