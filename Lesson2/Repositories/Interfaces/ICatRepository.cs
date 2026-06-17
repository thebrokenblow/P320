using Lesson2.Model;

namespace Lesson2.Repositories.Interfaces;

public interface ICatRepository
{
    Task AddAsync(Cat cat);
    Task EditAsync(Cat cat);
    Task DeleteByIdAsync(int id);
    Task<List<Cat>> GetFilteredAsync(string nameCat);
    Task<List<Cat>> GetAllAsync();
    Task<Cat> GetDetailsByIdAsync(int id);
}