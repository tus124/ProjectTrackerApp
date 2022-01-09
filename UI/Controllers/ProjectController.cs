#nullable disable
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectTrackerUI.Data;
using ProjectTrackerUI.Models;
using ProjectTrackerUI.Models.ViewModels;

namespace ProjectTrackerUI.Controllers
{
    //[Authorize]
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ProjectController> _logger;
        public ProjectController(ILogger<ProjectController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {           
            return View(await _db.Project.ToListAsync());
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _db.Project
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projects == null)
            {
                return NotFound();
            }
            var issues = await _db.Issue
                .Where(p => p.ProjectId == id)
                .Select(x => x)   //new { x.Id, x.Title, x.Description, x.StatusId, x.AssignedToId, x.SprintId, x.SprintTypeId }
                .ToListAsync();

            //dynamic myModel = new ExpandoObject();
            //myModel.Projects = projects;
            //myModel.Issues = issues;

            var tupleModel = new Tuple<Project, List<Issue>>(projects, issues);



            return View(tupleModel);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Active,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                _db.Add(project);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _db.Project.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }
            return View(projects);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Active,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    project.ModifiedBy = "";
                    project.ModifiedDate = DateTime.Now;

                    _db.Update(project);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _db.Project
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projects = await _db.Project.FindAsync(id);
            _db.Project.Remove(projects);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _db.Project.Any(e => e.Id == id);
        }
    }
}
