using Ardalis.Result;
using Core.Domain.Contracts.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var logService = httpContext.RequestServices.GetService<ILogsService>();
                await logService.AddExceptionLog(new Core.Domain.Entities.ExceptionLog()
                {
                    DateTime = DateTime.Now,
                    Message = ex.Message,  
                    StackTrace = ex.StackTrace,
                    RequestBody = await GetRequestBodyAsJson(httpContext),
                    RequestHeader = GetRequestHeadersAsJson(httpContext),
                    RequestQueryStrings = GetQueryStrings(httpContext),
                    UrlPath = httpContext.Request.Path
                });

                var httpStatusCode = HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";
                var result = string.Empty;
                Result response = Result.Error();

                switch (ex)
                {
                    case Exception eException:
                        response = Result.Error(eException.Message);
                        break;
                }
                httpContext.Response.StatusCode = (int)httpStatusCode;
                result = JsonSerializer.Serialize(response);
                await httpContext.Response.WriteAsync(result);
            }
        }

        public string GetRequestHeadersAsJson(HttpContext context)
        {
            var headers = context.Request.Headers;
            var json = JsonSerializer.Serialize(headers);
            return json;
        }

        public async Task<string> GetRequestBodyAsJson(HttpContext context)
        {
            string requestBody = "";
            using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            return requestBody;
        }

        public string GetQueryStrings(HttpContext context)
        {
            var queryStrings = context.Request.Query;

            string queryString = "";

            foreach (var query in queryStrings)
            {
                queryString += $"{query.Key}={query.Value}&";
            }

            queryString = queryString.TrimEnd('&');

            return queryString;
        }
    }
}
