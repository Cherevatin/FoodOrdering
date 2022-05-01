using Microsoft.AspNetCore.Builder;

using FoodOrdering.Presentation.Middlewares;

namespace FoodOrdering.Presentation.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExeptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
