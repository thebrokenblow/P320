using Lesson2.Model;

namespace Lesson2.Repositories.Interfaces;

public interface ICatRepository
{
    Task AddAsync(Cat cat);
    Task EditAsync(Cat cat);
    Task DeleteById(int id);
    Task<List<Cat>> GetAllAsync();
    Task<Cat> GetDetailsById(int id);
}