using Lesson2.Data;
using Lesson2.Model;
using Lesson2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lesson2.Repositories;

public class BreedRepository(CatDbContext catDbContext) : IBreedRepository
{
    private readonly CatDbContext _catDbContext = catDbContext;

    public async Task<List<Breed>> GetAllAsync()
    {
        return await _catDbContext.Breeds.ToListAsync();
    }
}
