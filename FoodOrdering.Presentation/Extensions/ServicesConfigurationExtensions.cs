using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Domain.Aggregates.OrderAggregate;

using FoodOrdering.Infrastructure;
using FoodOrdering.Infrastructure.Repositories; 

using FoodOrdering.Application.Services.DishService;
using FoodOrdering.Application.Services.MenuService;
using FoodOrdering.Application.Services.BasketService;
using FoodOrdering.Application.Services.OrderService;

using FoodOrdering.Presentation.AutoMapper;
using FoodOrdering.Application.AutoMapper;

namespace FoodOrdering.Presentation.Extensions
{
    public static class ServicesConfigurationExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, 
            IConfiguration configuration)
        {
            string connectionString =
                configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<FoodOrderingContext>(opt => opt.UseNpgsql(connectionString));

            services.AddTransient<IDishRepository, DishRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IDishService, DishService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(
                typeof(DishAutoMapperPresentation),
                typeof(DishAutoMapperApplication),
                typeof(MenuAutoMapperPresentation),
                typeof(MenuAutoMapperApplication),
                typeof(BasketAutoMapperPresentation),
                typeof(BasketAutoMapperApplication),
                typeof(OrderAutoMapperPresentation)
                );
        }
    }
}
