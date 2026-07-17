using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace Lesson2.Filters;

public class LogRequestAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var httpContext = context.HttpContext;
        var logger = httpContext.RequestServices.GetRequiredService<ILogger<LogRequestAttribute>>();

        // Логируем базовую информацию
        var request = httpContext.Request;
        var logBuilder = new StringBuilder();
        logBuilder.AppendLine($"HTTP {request.Method} {request.Path}{request.QueryString}");
        logBuilder.AppendLine($"Headers: {string.Join(", ", request.Headers.Select(h => $"{h.Key}={h.Value}"))}");

        logger.LogInformation(logBuilder.ToString());

        // Продолжаем выполнение
        await next();
    }
}