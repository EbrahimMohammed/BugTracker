using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTracker.Models;
using BugTracker.Persistance;

namespace BugTracker.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Edit(int Id)
        {
            var project = _context.Projects.Include(p => p.Developers).SingleOrDefault(c => c.Id == Id);

            if (project == null)
                return HttpNotFound();

            var updateProjectModel = new UpdateProjectModel
            {
                Id= project.Id,
                Name = project.Name,
                Description = project.Description
            };





            return View(updateProjectModel);
        }
    }
}