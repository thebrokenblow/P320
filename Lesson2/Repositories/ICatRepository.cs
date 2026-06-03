using Lesson2.Model;

namespace Lesson2.Repositories;

public interface ICatRepository
{
    Task AddAsync(Cat cat);
    Task<List<Cat>> GetAllAsync();
    Task<Cat> GetDetailsById(int id);
}