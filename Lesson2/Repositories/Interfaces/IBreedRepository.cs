using Lesson2.Model;

namespace Lesson2.Repositories.Interfaces;

public interface IBreedRepository
{
    Task<List<Breed>> GetAllAsync();
}