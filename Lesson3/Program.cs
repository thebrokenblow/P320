////Dependency Injection Container(DIC) — это инструмент для автоматического создания объектов и
////управления их зависимостями.
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

//Регистрация интерфейса + класса
services.AddSingleton<IСurrencyService, СurrencyService>();
services.AddSingleton<IOrderRepository, SqlOrderRepository>();
services.AddSingleton<IOrderRepository, NoSqlOrderRepository>();

services.AddSingleton<ICloudService, CloudService>();

services.AddSingleton<Order>();

var serviceProvider = services.BuildServiceProvider();

var order1 = serviceProvider.GetRequiredService<Order>();
var order2 = serviceProvider.GetRequiredService<Order>();

if (order1 == order2)
{
    
}

Console.ReadLine();




class SomeClass
{
    private SomeClass() { }

    private static SomeClass? _someClass;
    public static SomeClass GetInstance()
    {
        //if (_someClass == null)
        //{
            _someClass = new SomeClass();
        //}

        return _someClass;
    }
}



interface IOrderRepository
{
    public void Add(Product product);
}

class SqlOrderRepository : IOrderRepository
{
    public void Add(Product product)
    {
    }
}

class NoSqlOrderRepository : IOrderRepository
{
    public void Add(Product product)
    {
    }
}

interface IСurrencyService
{
    public int Get();
}

class СurrencyService : IСurrencyService
{
    public int Get()
    {
        //Сложная логика по взаимодейтсвию с сервисом по получению актульного курса валют
        return 1;
    }
}

class СurrencyServiceForRussia : IСurrencyService
{
    public int Get()
    {
        //Сложная логика по взаимодейтсвию с сервисом по получению актульного курса валют
        return 1;
    }
}


// Dependency Injection (DI, внедрение зависимостей) — это паттерн проектирования,
// при котором объект получает необходимые ему для работы компоненты
// (зависимости) извне, вместо того чтобы создавать их самостоятельно.

//
class Order
{
    private readonly IСurrencyService _сurrencyService;
    private readonly IOrderRepository _orderRepository;
    
    public Order(IСurrencyService сurrencyService, IOrderRepository orderRepository)
    {
        _сurrencyService = сurrencyService;
        _orderRepository = orderRepository;
    }

    public void Add(Product product)
    {
        var сurrency = _сurrencyService.Get();
        product.Price = product.Price * сurrency;

        _orderRepository.Add(product);
    }
}

interface ICloudService
{
    public byte[] Get();    
}

class CloudService : ICloudService
{
    public byte[] Get()
    {
        return null;
    }
}

class Order12
{
    private readonly IСurrencyService _сurrencyService;
    private readonly ICloudService _service;
    private readonly IOrderRepository _orderRepository;

    public Order12(IСurrencyService сurrencyService, IOrderRepository orderRepository, ICloudService cloudService)
    {
        _service = cloudService;
        _сurrencyService = сurrencyService;
        _orderRepository = orderRepository;
    }

    public void Add(Product product)
    {
        var сurrency = _сurrencyService.Get();
        product.Price = product.Price * сurrency;

        _orderRepository.Add(product);
    }
}


class Product
{
    //Свойства
    public decimal Price { get; set; }
}