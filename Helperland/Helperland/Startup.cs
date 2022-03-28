using Helperland.Models.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Web;

namespace Helperland
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
            

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(options =>
                {
                    options.LoginPath = "/";
                    options.LogoutPath = "/?logoutModal=true";
                    options.ExpireTimeSpan = TimeSpan.FromHours(1.5);
                    options.Cookie.MaxAge = options.ExpireTimeSpan;
                    options.SlidingExpiration = false;

                    options.Events = new CookieAuthenticationEvents()
                    {
                        OnRedirectToLogin = ctx =>
                        {
                            var redirectPath = ctx.RedirectUri;

                            if (redirectPath.Contains("?ReturnUrl"))
                            {
                                //remove the ReturnURL
                                var url = redirectPath.Substring(0, redirectPath.LastIndexOf("?ReturnUrl"));

                                ctx.Response.Redirect(url + "?modalRequest=true");
                            }
                            return Task.CompletedTask;
                        },
                        OnSigningOut = ctx =>
                        {
                            ctx.Response.Redirect("/?logoutModal=true");
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDbContext<HelperlandContext>(options =>
                options.UseSqlServer("Server=MIHIR;Database=Helperland;Trusted_Connection=True;"));
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
            }
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
