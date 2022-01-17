#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTrackerDataAccess.Data;
using ProjectTrackerDataAccess.Models;

namespace ProjectTrackerUI.Controllers
{
    //[Authorize]
    public class ProjectController : Controller
    {
        //private readonly ApplicationDbContext _db;
        private readonly IProjectData _projectData;
        private readonly IFeatureData _featureData;
        private readonly IIssueData _issueData;
        public ProjectController(IProjectData projectData, IFeatureData featureData, IIssueData issueData) 
        {
            _projectData = projectData;
            _featureData = featureData;
            _issueData = issueData;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {
            var results = await _projectData.GetProjects();
            return View(results.ToList());
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _projectData.GetProject(id.Value);
            if (projects == null)
            {
                return NotFound();
            }

            var features = await _featureData.GetFeaturesByProjectId(id.Value);
            var issues = await _issueData.GetIssuesByProjectId(id.Value);
            var tupleModel = new Tuple<ProjectModel, List<FeatureModel>, List<IssueModel>>(projects, features.ToList(), issues.ToList());

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
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Active,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                await _projectData.InsertProject(project, project.CreatedBy);
           
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

            var projects = await _projectData.GetProject(id.Value);
            projects.ModifiedDate = DateTime.Now;
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Active,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] ProjectModel project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _projectData.UpdateProject(project, project.ModifiedBy);
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

            var projects = await _projectData.GetProject(id.Value);
               
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
            //var projects = await _projectData.GetProject(id);

            await _projectData.DeleteProject(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            var projects = _projectData.GetProject(id).Result;

            if (projects == null)
            {
                return false;
            }
            return true;

        }
    }
}
