using Lesson2.Model;

namespace Lesson2.Repositories.Interfaces;

public interface ICatRepository
{
    List<Cat> Get();
    Cat GetById(int id);
}
