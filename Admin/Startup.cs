﻿using System;
using System.Globalization;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace Admin
{
    public class Startup
    {
        readonly Data.SchoolContext _schoolContext = new Data.SchoolContext();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // dotnet sql-cache create "Server=94.73.170.20;Database=u7801466_dbTestx;User Id=u7801466_userE86;Password=IDyk81F0;" dbo Sessions
            _schoolContext.Database.EnsureCreated();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<SchoolContext,SchoolContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICampusService, CampusService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IEventCategoryService, EventCategoryService>();
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IPageService, PageService>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(3);
            });

            services.AddDistributedSqlServerCache(o =>
            {
                o.ConnectionString = "Server=94.73.170.20;Database=u7801466_dbTestx;User Id=u7801466_userE86;Password=IDyk81F0;";
                o.SchemaName = "dbo";
                o.TableName = "Sessions";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var cultureInfo = new CultureInfo("tr-TR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}