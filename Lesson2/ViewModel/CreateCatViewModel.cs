using Lesson2.Model;

namespace Lesson2.ViewModel;

public class CreateCatViewModel
{
    public required Cat Cat { get; set; }
    public required List<Breed> Breeds { get; set; }
    public required Dictionary<string, List<string>> ErrorsByProperty { get; set; }
}
