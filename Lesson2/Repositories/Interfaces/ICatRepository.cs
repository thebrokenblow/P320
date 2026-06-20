using Lesson2.Model;

namespace Lesson2.Repositories.Interfaces;

public interface ICatRepository
{
    Task AddAsync(Cat cat);
    Task EditAsync(Cat cat);
    Task DeleteByIdAsync(int id);
    Task<(int countCats, List<Cat> filteredCats)> GetFilteredAsync(string nameCat, int countSkip, int pageSize);
    Task<int> GetCountAsync();
    Task<List<Cat>> GetAllAsync(int countSkip, int countTake);
    Task<Cat> GetDetailsByIdAsync(int id);
}