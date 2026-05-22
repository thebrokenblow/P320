using Microsoft.AspNetCore.Mvc;

namespace Lesson1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        //1,2 Вводная


        return View();
    }
}