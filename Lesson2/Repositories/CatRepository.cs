using Lesson2.Model;

namespace Lesson2.Repositories;

public class CatRepository
{
    private List<Cat> _cats;

    public CatRepository()
    {
        _cats = new List<Cat>
        {
            new() { Id = 1, Name = "Барсик", Description = "Любит спать на диване", Age = 2, PhotoSrc = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRsWnOH5VcpJMtinN689lmKB0ebMS_ttbvS3Q&s" },
            new() { Id = 2, Name = "Мурка", Description = "Очень ласковая", Age = 3, PhotoSrc = "https://files.moe-online.ru/media/2/0/3/9/8/1/0/781325f63532bbec2934a08f6df721e8/xrrmJdO8gjgmckcIEKHLfP07DJc2bGe3CSogmtbu-thumb_1280.png" },
            new() { Id = 3, Name = "Рыжик", Description = "Озорной рыжий кот", Age = 1, PhotoSrc = "https://vet-centre.by/wp-content/uploads/2016/11/kot-eti-udivitelnye-kotiki.jpg" },
        };
    }

    public List<Cat> Get()
    {
        return _cats;
    }

    public Cat GetById(int id)
    {
        return _cats.First(x => x.Id == id);
    }
}