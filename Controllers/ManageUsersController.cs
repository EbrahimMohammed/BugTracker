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



        [HttpPost]
        public ActionResult AssignRole(AssignRoleModel model)
        {


            //var userStore = new UserStore<IdentityUser>();
            //var userManager = new UserManager<IdentityUser>(userStore);
            //var roleStore = new RoleStore<IdentityRole>();
            //var roleManager = new RoleManager<IdentityRole>(roleStore);



            ////get old role of user if it exists
            //var oldRole = userManager.GetRoles(model.UserId).FirstOrDefault();


            //var newRole = roleManager.Roles.Single(r => r.Id == model.RoleId);


            ////remove old role
            //if (oldRole != null)
            //    userManager.RemoveFromRole(model.UserId, oldRole);

            //// add new role
            //userManager.AddToRole(model.UserId, newRole.Name);

            return Json(new { status = "Success", message = "Success" });

        }
    }
}