using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json;

using Rifoms.Domain.Context;
using Rifoms.Domain.Data.Entities.App;
using Rifoms.Domain.Infrastructure.Config;
using Rifoms.Domain.Infrastructure.Interfaces;
using Rifoms.Domain.Infrastructure.Services;
using Rifoms.Domain.Infrastructure.Settings;
using Rifoms.Web.Infrastructure.Access;
using Rifoms.Web.Infrastructure.Cookies;

using System;
using System.IO;

namespace Rifoms.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //string MySqlConn = ConnectionConfig.DevServerConnection;
            string MySqlConn = DebugConfig.IsDebug ? ConnectionConfig.DevLocalConnection : ConnectionConfig.DevServerConnection;

            //for AppDbContext for Database
            services.AddDbContext<RifomsDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
                options.EnableDetailedErrors(detailedErrorsEnabled: true);

                options.UseMySql(MySqlConn, ServerVersion.AutoDetect(MySqlConn), ma =>
                {
                    ma.MigrationsHistoryTable("app_migrationhistory");
                    ma.MigrationsAssembly("Rifoms.Web");
                })
                //.UseLoggerFactory()
                .EnableSensitiveDataLogging(true);
            }, ServiceLifetime.Transient);

            //for FormCollection Values set int.Maxvalue for sending MAxValues of formCollections
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
            });

            //for Mail Settings
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            #region FOR Identity User's
            ////for Identity users
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@/";
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                //settings for password
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<AppRole>()
            .AddDefaultUI()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<RifomsDbContext>();
            #endregion

            services.AddTransient<Func<RifomsDbContext>>(s => s.GetRequiredService<RifomsDbContext>);
            services.AddTransient<RifomsDbContext>();
            services.AddHttpContextAccessor();
            //services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<RifomsDbContext>();
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<IDbService, DbService>();
            services.AddTransient<IRazorRenderService, RazorRenderService>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = "TFomsRi";
            //    options.ExpireTimeSpan = TimeSpan.FromHours(8);
            //    options.Cookie.MaxAge = options.ExpireTimeSpan;
            //    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            //    options.SlidingExpiration = true;
            //    options.Cookie.SameSite = SameSiteMode.Strict;
            //    options.EventsType = typeof(CustomCookieAuthenticationEvents);

            //    options.LoginPath = new PathString("/Identity/Account/Login");
            //    options.LogoutPath = new PathString("/Identity/Account/Logout");
            //    options.AccessDeniedPath = new PathString("/Identity/Account/AccessDenied");
            //});

            //for sessions
            services.AddSession();

            //for cookies
            services.AddTransient<CustomCookieAuthenticationEvents>();
            services.AddHttpContextAccessor();
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers(options =>
                {
                    //options.ModelBinderProviders.Insert(0, new FromRouteUnsafeModelBinder());
                })
                .AddNewtonsoftJson(options =>
                {
                    //»справление ќЎ»Ѕ » ÷» Ћ»„Ќќ… «ј¬»—»ћќ—“»
                    //
                    //System.Text.Json.JsonException: A possible object cycle was detected.
                    //This can either be due to a cycle or if the object depth is larger than the
                    //maximum allowed depth of 32. Consider using ReferenceHandler.Preserve on
                    //JsonSerializerOptions to support cycles.
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });

            //Added Antiforgery for requests
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            // встраиваем сервис ZayavkaAccessHandler, ClientAccessHandler, ReportAccessHandler, kaploSverkaAccessHandler
            // для политики доступа к соответсувующим страницам
            services.AddTransient<IAuthorizationHandler, ZayavkaAccessHandler>();
            services.AddTransient<IAuthorizationHandler, ClientAccessHandler>();
            services.AddTransient<IAuthorizationHandler, ReportAccessHandler>();
            services.AddTransient<IAuthorizationHandler, SverkaAccessHandler>();

            //авторизация на основе политик , создание ограничений для политики
            //https://metanit.com/sharp/aspnet5/15.8.php
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ZayavkaPolicy", policy =>
                {
                    policy.Requirements.Add(new ZayavkaAccessRequirement(accessZayavka: true));
                });

                options.AddPolicy("ClientPolicy", policy =>
                {
                    policy.Requirements.Add(new ClientAccessRequirement(accessClient: true));
                });

                options.AddPolicy("SverkaPolicy", policy =>
                {
                    policy.Requirements.Add(new SverkaAccessRequirement(accessSverka: true));
                });

                options.AddPolicy("ReportPolicy", policy =>
                {
                    policy.Requirements.Add(new ReportAccessRequirement(accessReport: true));
                });
            });
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region REGION EXCEPTION PROCESS

            #region REGION EXCEPTION IS EXIST
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            #endregion

            #region REGION EXCEPTION ISN'T EXIST
            //app.UseExceptionHandler("/Error");
            #endregion

            #endregion

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Upload/UserFiles")),
                RequestPath = "/UserFiles"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Doc")),
                RequestPath = "/Doc"
            });

            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");

                #region ROUTE's FOR NEWs AND REGIONNEWDs

                routes.MapRoute(
                    name: "allnews",
                    template: "novosti/{seolink}.html",
                    defaults: new { controller = "Home", action = "AllNews" });

                routes.MapRoute(
                name: "content",
                template: "{seolink}.html",
                defaults: new { controller = "Home", action = "Content" });


                routes.MapRoute(
                  name: "content1",
                  template: "{id}/{seolink}.html",
                  defaults: new { controller = "Home", action = "Content" });

                routes.MapRoute(
                    name: "content2",
                    template: "{id}/{seolink1}/{seolink2}.html",
                    defaults: new { controller = "Home", action = "Content" });

                routes.MapRoute(
                    name: "content3",
                    template: "{id}/{seolink1}/{seolink2}/{seolink3}.html",
                    defaults: new { controller = "Home", action = "Content" });

                #endregion


                #region ROUTE's FOR ADMIN Panel

                routes.MapRoute(
                  name: "login",
                  template: "login.html",
                  defaults: new { controller = "Admin", action = "Login" });

                routes.MapRoute(
                  name: "forgot",
                  template: "forgot.html",
                  defaults: new { controller = "Admin", action = "Forgot" });

                routes.MapRoute(
                  name: "register",
                  template: "register.html",
                  defaults: new { controller = "Admin", action = "Register" });

                #endregion

            });
        }
    }
}

