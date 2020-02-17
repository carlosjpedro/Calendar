using Calendar.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Calendar.Api
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CalendarEventNotFound e)
            {

                httpContext.Response.Clear();
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { error = e.Message }));
            }
            catch (InvalidRequest e)
            {
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { error = e.Message }));
            }

        }
    }
}
