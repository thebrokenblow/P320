using Api.DTOs;
using Api.Exceptions;
using Api.Model;
using Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[SwaggerTag("Управление товарами")]
public class ProductsController(IProductRepositrory productsContext) : ControllerBase
{
    /// <summary>
    /// Получить список всех товаров
    /// </summary>
    /// <returns>Список товаров</returns>
    /// <response code="200">Успешное выполнение запроса</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpGet]
    [SwaggerOperation(Summary = "Получить все товары", Description = "Возвращает список всех товаров из базы данных")]
    [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Product>>> GetAllAsync()
    {
        var products = await productsContext.GetAllAsync();
        return Ok(products);
    }

    /// <summary>
    /// Получить товар по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор товара</param>
    /// <returns>Товар с указанным ID</returns>
    /// <response code="200">Успешное выполнение запроса</response>
    /// <response code="404">Товар с указанным ID не найден</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Получить товар по ID", Description = "Возвращает товар по указанному идентификатору")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Product>> GetByIdAsync(int id)
    {
        var product = await productsContext.GetByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    /// <summary>
    /// Создать новый товар
    /// </summary>
    /// <param name="createProduct">Данные для создания товара</param>
    /// <returns>Статус выполнения операции</returns>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     POST /api/products
    ///     {
    ///         "name": "Смартфон",
    ///         "description": "Современный смартфон с отличной камерой",
    ///         "price": 29999.99
    ///     }
    /// 
    /// Валидация:
    /// - Name: обязательное поле, не более 100 символов
    /// - Description: обязательное поле, не более 2000 символов
    /// - Price: должно быть больше 0
    /// </remarks>
    /// <response code="201">Товар успешно создан</response>
    /// <response code="400">Некорректные данные запроса</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpPost]
    [SwaggerOperation(Summary = "Создать новый товар", Description = "Создает новый товар с проверкой валидации")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CreateAsync([FromBody] CreateProduct createProduct)
    {
        if (string.IsNullOrEmpty(createProduct.Name) || createProduct.Name.Length > 100)
        {
            return BadRequest("Имя товара обязательно и не должно превышать 100 символов");
        }

        if (string.IsNullOrEmpty(createProduct.Description) || createProduct.Description.Length > 2000)
        {
            return BadRequest("Описание товара обязательно и не должно превышать 2000 символов");
        }

        if (createProduct.Price <= 0)
        {
            return BadRequest("Цена товара должна быть больше 0");
        }

        await productsContext.CreateAsync(createProduct);
        return Created();
    }

    /// <summary>
    /// Обновить существующий товар
    /// </summary>
    /// <param name="updateProduct">Данные для обновления товара</param>
    /// <returns>Статус выполнения операции</returns>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     PUT /api/products
    ///     {
    ///         "id": 1,
    ///         "name": "Смартфон Pro",
    ///         "description": "Обновленная модель с улучшенными характеристиками",
    ///         "price": 34999.99
    ///     }
    /// 
    /// Валидация:
    /// - Name: обязательное поле, не более 100 символов
    /// - Description: обязательное поле, не более 2000 символов
    /// - Price: должно быть больше 0
    /// </remarks>
    /// <response code="200">Товар успешно обновлен</response>
    /// <response code="400">Некорректные данные запроса или товар не найден</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpPut]
    [SwaggerOperation(Summary = "Обновить товар", Description = "Обновляет существующий товар с проверкой валидации")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateProduct updateProduct)
    {
        if (string.IsNullOrEmpty(updateProduct.Name) || updateProduct.Name.Length > 100)
        {
            return BadRequest("Имя товара обязательно и не должно превышать 100 символов");
        }

        if (string.IsNullOrEmpty(updateProduct.Description) || updateProduct.Description.Length > 2000)
        {
            return BadRequest("Описание товара обязательно и не должно превышать 2000 символов");
        }

        if (updateProduct.Price <= 0)
        {
            return BadRequest("Цена товара должна быть больше 0");
        }

        await productsContext.UpdateAsync(updateProduct);
        return Ok();
    }

    /// <summary>
    /// Удалить товар
    /// </summary>
    /// <param name="id">Идентификатор удаляемого товара</param>
    /// <returns>Статус выполнения операции</returns>
    /// <response code="200">Товар успешно удален</response>
    /// <response code="404">Товар с указанным ID не найден</response>
    /// <response code="400">Ошибка при удалении товара</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Удалить товар", Description = "Удаляет товар по указанному идентификатору")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        try
        {
            await productsContext.DeleteAsync(id);
        }
        catch (NotFoundException)
        {
            return NotFound($"Товар с ID {id} не найден");
        }
        catch (Exception)
        {
            return BadRequest("Произошла ошибка при удалении товара");
        }

        return Ok();
    }
}