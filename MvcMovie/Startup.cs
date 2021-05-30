using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Logging;
using MvcMovie.NLayerApp.DAL.Interfaces;
using MvcMovie.NLayerApp.BLL.Interfaces;
using MvcMovie.NLayerApp.DAL.Repositories;
using MvcMovie.NLayerApp.BLL.Services;
using MvcMovie.NLayerApp.DAL.EF;

namespace MvcMovie
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<MvcMovieContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("MvcMovieContext");

                if (Environment.IsDevelopment())
                {
                    options.UseSqlite(connectionString);
                }
                else
                {
                    options.UseSqlServer(connectionString);
                }
            });


            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            services.AddScoped<IOrderService, OrderService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Movies/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseMiddleware<ResponseLoggingMiddleware>();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movies}/{action=Index}/{id?}");
            });
        }
    }
}
