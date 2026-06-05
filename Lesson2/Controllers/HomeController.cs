
using Lesson2.Model;
using Lesson2.Repositories.Interfaces;
using Lesson2.ViewModel;
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
    private readonly IBreedRepository _breedRepository;

    public HomeController(ICatRepository catRepository, IBreedRepository breedRepository)
    {
        _catRepository = catRepository;
        _breedRepository = breedRepository;
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

    public async Task<IActionResult> Delete(int id)
    {
        await _catRepository.DeleteById(id);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cat = await _catRepository.GetDetailsById(id);
        var breeds = await _breedRepository.GetAllAsync();

        var editCatViewModel = new EditCatViewModel()
        {
            Cat = cat,
            Breeds = breeds
        };

        return View(editCatViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditCatViewModel editCatViewModel)
    {
        editCatViewModel.Breeds = await _breedRepository.GetAllAsync();
        await _catRepository.EditAsync(editCatViewModel.Cat);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Create()
    {
        var cat = new Cat
        {
            Name = string.Empty,
            Description = string.Empty,
            Age = default,
            PhotoSrc = string.Empty,
            BreedId = 1
        };

        var breeds = await _breedRepository.GetAllAsync();

        var createCatViewModel = new CreateCatViewModel()
        {
            Cat = cat,
            Breeds = breeds,
            ErrorsByProperty = []
        };

        return View(createCatViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCatViewModel createCatViewModel)
    {
        createCatViewModel.Breeds = await _breedRepository.GetAllAsync();

        var errorsByProperty = new Dictionary<string, List<string>>
        {
            ["Name"] = [],
            ["Description"] = []
        };
        
        if (createCatViewModel.Cat.Name == null)
        {
            errorsByProperty["Name"].Add("Вы ввели пустое имя");
        }

        if (createCatViewModel.Cat.Description == null)
        {
            errorsByProperty["Description"].Add("Вы ввели пустое описание");
        }

        if (createCatViewModel.Cat.Description?.Length > 1000)
        {
            errorsByProperty["Description"].Add("Вы ввели слишком большое описание, максимальный размер 1000 символов");
        }

        if (errorsByProperty["Name"].Count > 0 || errorsByProperty["Description"].Count > 0)
        {
            createCatViewModel.ErrorsByProperty = errorsByProperty;
            return View(createCatViewModel);
        }

        createCatViewModel.Cat.Name = createCatViewModel.Cat.Name.Trim();
        createCatViewModel.Cat.Description = createCatViewModel.Cat.Description.Trim();

        await _catRepository.AddAsync(createCatViewModel.Cat);

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Contact()
    {
        return View();
    }
}
