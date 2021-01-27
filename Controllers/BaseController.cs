 using System.Configuration;
 using System.Data.Entity;
 using System.Linq;
 using System.Web.Mvc;
 using BugTracker.Core.Domain;
 using BugTracker.Models;
 using BugTracker.Persistance;
 using Microsoft.AspNet.Identity;
 using Microsoft.AspNet.Identity.EntityFramework;

 namespace BugTracker.Controllers
{
    public class BaseController :Controller
    {

        protected ApplicationDbContext Context;
        protected string UploadFolder;
        protected static UserStore<IdentityUser> UserStore;
        protected static UserManager<IdentityUser> UserManager;
        protected static RoleStore<IdentityRole> RoleStore;
        protected static RoleManager<IdentityRole> RoleManager;


        public BaseController()
        {
            Context = new ApplicationDbContext();
            UploadFolder = ConfigurationManager.AppSettings["UploadFolder"];
            UserStore = new UserStore<IdentityUser>();
            UserManager = new UserManager<IdentityUser>(UserStore);
            RoleStore = new RoleStore<IdentityRole>();
            RoleManager = new RoleManager<IdentityRole>(RoleStore);
        }



        protected bool IsAuthorizedUser(int projectId)
        {

            var project = Context
                .Projects
                .Include(p => p.Users)
                .Single(p => p.Id == projectId);

            if (User.IsInRole(Roles.CanManageUsers))
                return true;

            var authorized =  project.Users.Any(d => d.Id == User.Identity.GetUserId());


            return authorized;

        }


        protected override void Dispose(bool disposing)
        {

            Context.Dispose();

            base.Dispose(disposing);
        }


    }
}