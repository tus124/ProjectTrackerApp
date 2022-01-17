using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTrackerUI.Controllers;
public class IssueController : Controller
{
    // GET: IssueController
    public ActionResult Index()
    {
        return View();
    }

    // GET: IssueController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: IssueController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: IssueController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: IssueController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: IssueController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: IssueController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: IssueController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
