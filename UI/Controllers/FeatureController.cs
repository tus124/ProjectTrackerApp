using Microsoft.AspNetCore.Mvc;
using ProjectTrackerDataAccess.LookupTables.Data;
using ProjectTrackerDataAccess.LookupTables.Models;
using ProjectTrackerDataAccess.Models;

namespace ProjectTrackerUI.Controllers;
public class FeatureController : Controller
{
    private readonly IFeatureData _featureData;
    private readonly IPriorityData _priorityData;
    public FeatureController(IFeatureData featureData, IPriorityData priorityData)
    {
        _featureData = featureData;
        _priorityData = priorityData;
    }

    // GET: Feature
    //public async Task<IActionResult> Index()
    //{
    //    return View();
    //}

    //// GET: Feature/Details/5
    //public async Task<IActionResult> Details(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var feature = await _context.Feature
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (feature == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(feature);
    //}

    //// GET: Feature/Create
    //public IActionResult Create()
    //{
    //    return View();
    //}

    //// POST: Feature/Create
    //// To protect from overposting attacks, enable the specific properties you want to bind to.
    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create([Bind("Id,Title,Description,ProjectId,PriorityId,RiskId,ClassificationId,Active,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] FeatureModel feature)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _context.Add(feature);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(feature);
    //}

    // GET: Feature/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var feature = await _featureData.GetFeature(id.Value);

        if (feature == null)
        {
            return NotFound();
        }


        
        var priorityList = await _priorityData.GetAll();

        ViewBag.PriorityList = priorityList;
        //var model = new ValueTuple<FeatureModel, List<PriorityModel>>(feature, priorityList.ToList());
        


        return View(feature);
    }

    // POST: Feature/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ProjectId,PriorityId,RiskId,ClassificationId,Active,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] FeatureModel feature)
    {
        if (id != feature.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                string userName = feature.ModifiedBy == null ? "system" : feature.ModifiedBy.ToString();
                await _featureData.UpdateFeature(feature, userName);
            }
            catch (Exception ex)
            {
                if (!FeatureExists(feature.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }
            //return RedirectToAction(nameof(Index));
        }
        RouteData.Values.Remove("id");
        return RedirectToAction("Details", "Project", new { id = feature.ProjectId } );
    }

    //// GET: Feature/Delete/5
    //public async Task<IActionResult> Delete(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var feature = await _context.Feature
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (feature == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(feature);
    //}

    //// POST: Feature/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> DeleteConfirmed(int id)
    //{
    //    var feature = await _context.Feature.FindAsync(id);
    //    _context.Feature.Remove(feature);
    //    await _context.SaveChangesAsync();
    //    return RedirectToAction(nameof(Index));
    //}

    private bool FeatureExists(int id)
    {
        return _featureData.GetFeature(id).Result == null ? false : true;
    }
}
