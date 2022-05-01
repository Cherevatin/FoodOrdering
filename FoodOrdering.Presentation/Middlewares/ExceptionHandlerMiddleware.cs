using System;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;

using Microsoft.AspNetCore.Http;

using FoodOrdering.Domain.Exception;
using FoodOrdering.Application.Exception;

namespace FoodOrdering.Presentation.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";

                response.StatusCode = ex switch
                {
                    DomainNotFoundException => (int)HttpStatusCode.NotFound,
                    ApplicationNotFoundException => (int)HttpStatusCode.NotFound,
                    ApplicationValidationException => (int)HttpStatusCode.BadRequest,
                    ApplicationAlreadyExistsException => (int)HttpStatusCode.Conflict,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                await httpContext.Response.WriteAsync(new Error
                {
                    StatusCode = response.StatusCode,
                    Message = ex.Message,
                    Exception = ex.GetType().ToString(),
                    StackTrace = ex.StackTrace

                }.ToString());
            }
        }

        private class Error
        {
            public int StatusCode { get; set; }

            public string Message { get; set; }

            public string Exception { get; set; }

            public string StackTrace { get; set; }

            public override string ToString()
            {
                return JsonSerializer.Serialize(this);
            }
        }
    }
}
