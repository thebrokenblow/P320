using Lesson2.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lesson2.ViewModel;

public class CreateCatViewModel
{
    public required Cat Cat { get; set; }
    public required List<SelectListItem> Breeds { get; set; }
    public required Dictionary<string, List<string>> ErrorsByProperty { get; set; }
}
