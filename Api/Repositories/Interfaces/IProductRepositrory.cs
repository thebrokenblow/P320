using Api.DTOs;
using Api.Model;

namespace Api.Repositories.Interfaces;

public interface IProductRepositrory
{
    /// <summary>
    /// Получение всех объектов продуктов из хранилища данных
    /// </summary>
    /// <returns>Список продуктов</returns>
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task CreateAsync(CreateProduct product);
    Task UpdateAsync(UpdateProduct product);
    Task DeleteAsync(int id);
}