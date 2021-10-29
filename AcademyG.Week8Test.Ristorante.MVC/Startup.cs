using AcademyG.Week8Test.Ristorante.Core.BusinessLayer;
using AcademyG.Week8Test.Ristorante.Core.Interfaces;
using AcademyG.Week8Test.Ristorante.EF;
using AcademyG.Week8Test.Ristorante.EF.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.MVC
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
            services.AddControllersWithViews();
            services.AddTransient<IMainBusinessLayer, MainBusinessLayer>();
            services.AddTransient<IMenuRepository, MenuRepositoryEF>();
            services.AddTransient<IPlateRepository, PlateRepositoryEF>();
            services.AddTransient<IUserRepository, UserRepositoryEF>();

            services.AddDbContext<RestaurantContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("RestaurantDB"));
            });

            //aggiungiamo il filtro di autenticatione
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                    options =>
                    {
                        options.LoginPath = new PathString("/Users/Login");
                        options.AccessDeniedPath = new PathString("/Users/Forbidden");
                    }
                );

            //filtro di autorizzazione
            services.AddAuthorization(
                    options =>
                    {
                        options.AddPolicy("RestorerUser", policy => policy.RequireRole("Restorer"));
                        options.AddPolicy("ClientUser", policy => policy.RequireRole("Client"));
                    }
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
