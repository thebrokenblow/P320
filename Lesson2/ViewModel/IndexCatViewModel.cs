using Lesson2.Model;

namespace Lesson2.ViewModel;

public class IndexCatViewModel
{
    public required FilteredCatsViewModel FilteredCatsViewModel { get; init; }
    public required PaginatedViewModelList<Cat> PaginatedViewModelList { get; init; }
}
