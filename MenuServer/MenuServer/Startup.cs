using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MenuServer.Models;
using MenuServer.Repositories;
using MenuServer.Services;

namespace MenuServer
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
            services.AddControllers(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddCors();

            services.AddDbContext<MenuServerContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MenuServerContext")));

            services.AddDbContext<MenuServerContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MenuServerContext")));

            services.AddScoped(typeof(IDayOfWeekRepository), typeof(DayOfWeekRepository));
            services.AddScoped(typeof(ITimeOfDayRepository), typeof(TimeOfDayRepository));
            services.AddScoped(typeof(IDishRepository), typeof(DishRepository));
            services.AddScoped(typeof(IDishIngredientRepository), typeof(DishIngredientRepository));
            services.AddScoped(typeof(IMenuRepository), typeof(MenuRepository));
            services.AddScoped(typeof(IIngredientRepository), typeof(IngredientRepository));

            services.AddScoped(typeof(IIngredientService), typeof(IngredientService));
            services.AddScoped(typeof(IDishService), typeof(DishService));
            services.AddScoped(typeof(IMenuService), typeof(MenuService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
