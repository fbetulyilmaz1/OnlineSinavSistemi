using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Bll.Concrete;
using OnlineSinavSistemi.Dal.Abstract;
using OnlineSinavSistemi.Dal.Concrete;

namespace OnlineSinavSistemi.UI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<OnlineSinavSistemiContext>();
            //services.AddScoped<IBransService, BransService>();
            //services.AddScoped<IBransRepository, BransRepository>();
            //services.AddScoped<IDersService, DersService>();
            //services.AddScoped<IDersRepository, DersRepository>();
            //services.AddScoped<IKullaniciSinavService, KullaniciSinavService>();
            //services.AddScoped<IKullaniciSinavRepository, KullaniciSinavRepository>();
            //services.AddScoped<IKullaniciService, KullaniciService>();
            //services.AddScoped<IKullaniciRepository, KullaniciRepository>();
            //services.AddScoped<ISinavService, SinavService>();
            //services.AddScoped<ISinavRepository, SinavRepository>();
            //services.AddScoped<IKursMerkeziService, KursMerkeziService>();
            //services.AddScoped<IKursMerkeziRepository, KursMerkeziRepository>();
            //services.AddScoped<IKursDersService, KursDersService>();
            //services.AddScoped<IKursDersRepository, KursDersRepository>();
            //services.AddScoped<IRolService, RolService>();
            //services.AddScoped<IRolRepository, RolRepository>();
            //services.AddScoped<ISikayetService, SikayetService>();
            //services.AddScoped<ISikayetRepository, SikayetRepository>();
            //services.AddScoped<ISoruService, SoruService>();
            //services.AddScoped<ISoruRepository, SoruRepository>();
            //services.AddScoped<ISinavSoruService, SinavSoruService>();
            //services.AddScoped<ISinavSoruRepository, SinavSoruRepository>();
            //services.AddScoped<IYorumService, YorumService>();
            //services.AddScoped<IYorumRepository, YorumRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".OSS.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.IsEssential = true;

            });
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            services.AddDistributedRedisCache(opytion => { opytion.Configuration = "localhost:6379"; });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<OnlineSinavSistemiContext>();
                //context.Database.Migrate();

                //migration olmasaydı
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
            }



            //app.UseFileServer();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "Template")),
                RequestPath = "/tmp"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
           Path.Combine(Directory.GetCurrentDirectory(), "Areas/Admin/Images/BransLogo")),
             
                RequestPath = "/branslogos"
            });

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(x =>
            {
                x.MapRoute("areas", "{area:exists}/{controller}/{action}/{id?}", new { controller = "Brans", Action = "Ekle" });//varsa çatışmasın
                x.MapRoute("default", "{controller}/{action}/{id?}", new { controller = "Home", Action = "Index" });
            });

        }
    }
}
