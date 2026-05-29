
using Lesson2.Repositories;
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

    public async Task<IActionResult> Index()
    {
        var cats = await _catRepository.GetAllAsync();

        return View(cats);
    }

    public async Task<IActionResult> Details(int id)
    {
        var cat = await _catRepository.GetDetailsById(id);

        return View(cat);
    }

    public IActionResult Contact()
    {
        return View();
    }
}
