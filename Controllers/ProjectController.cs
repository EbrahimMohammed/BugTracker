using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTracker.Core.Domain;
using BugTracker.Models;
using BugTracker.Persistance;
using Microsoft.AspNet.Identity;

namespace BugTracker.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public ProjectController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Project
        public ActionResult Index()
        {

            if (User.IsInRole(Roles.CanManageProjects))
            {
                return View("Index.Manager");
            }


            return View("Index.User");
        }


        [Authorize(Roles = Roles.CanManageProjects)]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = Roles.CanManageProjects)]
        public ActionResult Edit(int id)
        {
            var project = _context.Projects.Include(p => p.Users).SingleOrDefault(c => c.Id == id);

            if (project == null)
                return HttpNotFound();

            var updateProjectModel = new UpdateProjectModel
            {
                Id= project.Id,
                Name = project.Name,
                Description = project.Description,
                
            };


            return View(updateProjectModel);
        }

        public ActionResult Details(int id)
        {


            var project = _context
                .Projects
                .Include(p => p.Users)
                .SingleOrDefault(p => p.Id == id);



            if (project == null)
                return HttpNotFound();


            if (!IsAuthorizedUser(project.Id))
                return HttpNotFound();


            return View(project);

        }


    }
}