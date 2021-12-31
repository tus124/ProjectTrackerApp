using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectTrackerUI.Models.ViewModels
{
    public class ProjectVM
    {
        public Project Project { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}
