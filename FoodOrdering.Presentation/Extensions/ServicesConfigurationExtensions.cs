using System.Text;

using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Swashbuckle.AspNetCore.Filters;

using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Domain.Aggregates.OrderAggregate;
using FoodOrdering.Domain.Aggregates.UserAggregate;

using FoodOrdering.Infrastructure;
using FoodOrdering.Infrastructure.Repositories;

using FoodOrdering.Application.Services.DishService;
using FoodOrdering.Application.Services.MenuService;
using FoodOrdering.Application.Services.BasketService;
using FoodOrdering.Application.Services.OrderService;
using FoodOrdering.Application.AutoMapper;
using FoodOrdering.Application.Services.UserService;

using FoodOrdering.Presentation.AutoMapper;

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
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IDishService, DishService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();

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

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodOrdering", Version = "v1" });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    Description = "Bearer Authorization with JWT Token)",
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey

                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            string tokenString =
                configuration["Token"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenString)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }
    }
}
