
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rifoms.Domain.Context;
using Rifoms.Domain.Data.Entities.App;
using Rifoms.Domain.Data.Entities.Web;
using Rifoms.Web.Infrastructure.DbInitializer;
using System;
using System.Threading.Tasks;

namespace Rifoms.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var rolesManager = services.GetRequiredService<RoleManager<AppRole>>();
                    var dbContext = services.GetRequiredService<RifomsDbContext>();
                    //var us = new CmsUser();
                  
                    await RoleInitializer.InitializeAsync(userManager, rolesManager, dbContext);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
