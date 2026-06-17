using Lesson2.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Lesson2.Extensions;

public static class ControllerExtension
{
    public static string GetName(this Controller controller, string nameController)
    {
        return nameController.Replace("Controller", string.Empty);
    }
}