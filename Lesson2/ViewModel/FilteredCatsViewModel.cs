using Lesson2.Model;

namespace Lesson2.ViewModel;

public class FilteredCatsViewModel
{
    public required string NameCat { get; init; }
    public required List<Cat> FilteredCats { get; init; }
}
