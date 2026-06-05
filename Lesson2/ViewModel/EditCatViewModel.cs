using Lesson2.Model;

namespace Lesson2.ViewModel;

public class EditCatViewModel
{
    public required Cat Cat { get; set; }
    public required List<Breed> Breeds { get; set; }
}