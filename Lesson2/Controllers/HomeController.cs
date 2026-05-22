using Lesson2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lesson2.Controllers;

public class HomeController : Controller
{
    private readonly CatRepository _catRepository;
    public HomeController()
    {
        _catRepository = new CatRepository();
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
