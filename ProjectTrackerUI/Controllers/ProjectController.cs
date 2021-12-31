#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectTrackerUI.Data;
using ProjectTrackerUI.Models;

namespace ProjectTrackerUI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _db;
       // private readonly ILogger<ProjectController> _logger;
        public ProjectController(ApplicationDbContext db)
        {
            //_logger = logger;  ILogger<ProjectController> logger, 
            _db = db;
        }

        // GET: Project
        public IActionResult Index()
        {
            //return View(await _context.ProjectViewModel.ToListAsync());
            IEnumerable<Project> projects = _db.Projects;

          //  var lists = _db.Projects.ToList();


            return View(projects);
        }

        //// GET: Project/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var projectViewModel = await _db.ProjectViewModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (projectViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(projectViewModel);
        //}

        //// GET: Project/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Project/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Description,Active,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Project projectViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(projectViewModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(projectViewModel);
        //}

        //// GET: Project/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var projectViewModel = await _context.ProjectViewModel.FindAsync(id);
        //    if (projectViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(projectViewModel);
        //}

        //// POST: Project/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Active,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Project projectViewModel)
        //{
        //    if (id != projectViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(projectViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProjectViewModelExists(projectViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(projectViewModel);
        //}

        //// GET: Project/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var projectViewModel = await _context.ProjectViewModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (projectViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(projectViewModel);
        //}

        //// POST: Project/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var projectViewModel = await _context.ProjectViewModel.FindAsync(id);
        //    _context.ProjectViewModel.Remove(projectViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProjectViewModelExists(int id)
        //{
        //    return _context.ProjectViewModel.Any(e => e.Id == id);
        //}
    }
}
