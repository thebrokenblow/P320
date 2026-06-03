using Lesson2.Data;
using Lesson2.Model;
using Microsoft.EntityFrameworkCore;

namespace Lesson2.Repositories;

public class CatRepository : ICatRepository
{
    private readonly CatDbContext _catDbContext;
    public CatRepository(CatDbContext catDbContext)
    {
        _catDbContext = catDbContext;
    }

    public async Task AddAsync(Cat cat)
    {
        await _catDbContext.AddAsync(cat);
        await _catDbContext.SaveChangesAsync();
    }

    public async Task<List<Cat>> GetAllAsync()
    {
        return await _catDbContext.Cats.ToListAsync();
    }

    public async Task<Cat> GetDetailsById(int id)
    {
        return await _catDbContext.Cats.Include(x => x.Breed).FirstAsync(x => x.Id == id);
    }
}
