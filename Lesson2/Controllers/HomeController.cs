using Lesson2.Repositories;
using Lesson2.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lesson2.Controllers;

//D
//Модули верхнего уровня не должны зависеть от модулей нижнего уровня.
//Оба типа модулей должны зависеть от абстракций.


//Dependency Injection (DI, внедрение зависимостей) — это паттерн проектирования,
//при котором объект получает необходимые ему для работы компоненты (зависимости) извне,
//вместо того чтобы создавать их самостоятельно.

//S
//D
//DI + (DI container)
public class HomeController : Controller
{
    private readonly ICatRepository _catRepository;
    public HomeController(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }

    public IActionResult Index()
    {
        var cats = _catRepository.Get();

        return View(cats);
    }

    public IActionResult Details(int id)
    {
        var cat = _catRepository.GetById(id);

        return View(cat);
    }
}
