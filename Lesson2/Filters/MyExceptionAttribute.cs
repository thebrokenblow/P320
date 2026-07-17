using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lesson2.Filters;

public class MyExceptionAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        context.Result = new JsonResult(new { error = "Ошибка" }) { StatusCode = 500 };
        context.ExceptionHandled = true;
    }
}