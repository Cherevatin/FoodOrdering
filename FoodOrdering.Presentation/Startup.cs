using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FoodOrdering.Infrastructure;
using FoodOrdering.Infrastructure.Repositories;
using FoodOrdering.Application.AutoMapper;
using FoodOrdering.Presentation.AutoMapper;
using FoodOrdering.Application.Services.MenuService;
using FoodOrdering.Application.Services.DishService;
using FoodOrdering.Application.Services.BasketService;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Domain.Aggregates.OrderAggregate;
using FoodOrdering.Application.Services.OrderService;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FoodOrdering.Presentation
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
            services.AddAutoMapper(
                typeof(DishAutoMapperPresentation),
                typeof(DishAutoMapperApplication),
                typeof(MenuAutoMapperPresentation), 
                typeof(MenuAutoMapperApplication),
                typeof(BasketAutoMapperPresentation),
                typeof(BasketAutoMapperApplication),
                typeof(OrderAutoMapperPresentation)
                );


            string connectionString = 
                Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<FoodOrderingContext>(opt => opt.UseNpgsql(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IDishRepository, DishRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IDishService, DishService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(opt =>
            //    {
            //        opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            //    });

            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodOrdering", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodOrdering v1"));
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
