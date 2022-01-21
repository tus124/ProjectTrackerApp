using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjectTrackerUI.ViewComponents;

[ViewComponent(Name = "Feature")]
public class FeatureViewComponent : ViewComponent
{
    private readonly IFeatureData _featureData;
    public FeatureViewComponent(IFeatureData featureData)
    {
        _featureData = featureData;
    }
    public async Task<IViewComponentResult> InvokeAsync(int projectId)
    {

        var features = await _featureData.GetFeaturesByProjectId(projectId);
        return View(features);
        //return Content("Hello");
    }
}
