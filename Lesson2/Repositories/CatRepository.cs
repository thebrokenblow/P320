using Lesson2.Data;
using Lesson2.Model;
using Lesson2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lesson2.Repositories;

public class CatRepository(CatDbContext catDbContext) : ICatRepository
{
    private readonly CatDbContext _catDbContext = catDbContext;

    public async Task AddAsync(Cat cat)
    {
        await _catDbContext.AddAsync(cat);
        await _catDbContext.SaveChangesAsync();
    }

    public async Task EditAsync(Cat cat)
    {
        var editingCat = await GetById(cat.Id);

        editingCat.BreedId = cat.BreedId;
        editingCat.DateOfBirth = cat.DateOfBirth;
        editingCat.Description = cat.Description;
        editingCat.Name = cat.Name;
        editingCat.PhotoSrc = cat.PhotoSrc;

        await _catDbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var cat = await GetById(id);

        _catDbContext.Remove(cat);
        await _catDbContext.SaveChangesAsync();
    }

    public async Task<List<Cat>> GetAllAsync()
    {
        return await _catDbContext.Cats.ToListAsync();
    }

    public async Task<List<Cat>> GetFilteredAsync(string nameCat)
    {
        return await _catDbContext.Cats.Where(cat => cat.Name.Contains(nameCat)).ToListAsync();
    }

    public async Task<Cat> GetById(int id)
    {
        return await _catDbContext.Cats.FirstAsync(x => x.Id == id);
    }

    public async Task<Cat> GetDetailsByIdAsync(int id)
    {
        return await _catDbContext.Cats.Include(x => x.Breed).FirstAsync(x => x.Id == id);
    }
}
