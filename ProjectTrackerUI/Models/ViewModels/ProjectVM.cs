using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectTrackerUI.Models.ViewModels
{
    public class ProjectVM
    {
        public Project Project { get; set; }
        public List<Issue> Issues { get; set; }

        public ProjectVM()
        {
            Project = new Project();
            Issues = new List<Issue>();

        }
    }
}
