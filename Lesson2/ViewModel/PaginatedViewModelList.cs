namespace Lesson2.ViewModel;

public class PaginatedViewModelList<T>
{
    public List<T> Items { get; set; }
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;

    public PaginatedViewModelList(List<T> items, int count, int pageIndex, int pageSize)
    {
        Items = items;
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }


}
