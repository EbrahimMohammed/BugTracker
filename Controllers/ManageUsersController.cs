using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTracker.Models;
using BugTracker.Persistance;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugTracker.Controllers
{
    public class ManageUsersController : Controller
    {
        private ApplicationDbContext _context;

        public ManageUsersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: ManageUsers
        public ActionResult Index()
        {
            var model = new ManageUsersModel
            {
                Roles = _context.Roles.ToList()
            };


            return View(model);
        }


        public ActionResult Create()
        {

            var model = new CreateUserViewModel()
            {
                Roles = _context.Roles.ToList()
            };


            return View(model);
        }

    }
}