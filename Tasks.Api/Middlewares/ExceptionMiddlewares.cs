using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tasks.Api.Middlewares
{
    public class ExceptionMiddlewares
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddlewares> _logger;

        public ExceptionMiddlewares(RequestDelegate next, ILogger<ExceptionMiddlewares> logger) 
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try {
                await _next(context);
            } catch (Exception ex) {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception) 
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            _logger.LogError($"An unhandled exception occurred:  {exception}");

            using (var stream = new MemoryStream()) {
                var obj = new {
                    path = context.Request.Path.HasValue ? context.Request.Path.Value : "",
                    message = $"An unexpected error occurred: {exception.Message}",
                    type = exception.GetType().FullName
                };
                await JsonSerializer.SerializeAsync(stream, obj, new JsonSerializerOptions { WriteIndented = true });
                stream.Position = 0;
                using var reader = new StreamReader(stream);
                var body = await reader.ReadToEndAsync();
                await context.Response.WriteAsync(body);
            }
        }
    }
}