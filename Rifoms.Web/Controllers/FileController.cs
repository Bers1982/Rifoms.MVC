using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rifoms.Domain.Data.Models.Base;
using Rifoms.Domain.Infrastructure.Interfaces;
using Rifoms.Web.Controllers.Base;

namespace Rifoms.Web.Controllers
{
    public class FileController : BaseController<FileController>
    {
        public FileController(IHttpContextAccessor httpContext,
            IWebHostEnvironment webHostEnvironment,
            IDbService dbService,
            ILogger<FileController> logger)
            : base(httpContext, webHostEnvironment, dbService, logger)
        {
        }
        public async Task<IActionResult> Download()
        {
            //var model = new BaseModel();
            string seolink = Request.Path.Value;
            string fileName = await dbService.GetFileNameBySeolinkAsync(seolink);
            string filePath = Path.Combine(webHostEnvironment.ContentRootPath, "Upload\\UserFiles", fileName);
            if (System.IO.File.Exists(filePath))
            {
                string contentType = string.Empty;  
                string extension = Path.GetExtension(filePath);

                switch (extension)
                {
                    case ".doc":contentType= "application/msword";
                        break;
                    case ".docx":
                        contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                        break;
                    case ".xls":
                        contentType = "application/vnd.ms-excel";
                        break;
                    case ".xlsx":
                        contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        break;
                    case ".rar":
                        contentType = "application/vnd.rar";
                        break;
                    case ".zip":
                        contentType = "application/zip";
                        break;
                }
                return PhysicalFile(filePath, contentType, fileName);
            }
            return NotFound();
        }
    }
}
