using System.Web.Http;
using BugTracker.Models;
using BugTracker.Persistance;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugTracker.Controllers.Api
{
    public class BaseApiController: ApiController
    {
        protected readonly ApplicationDbContext Context;


        protected UserStore<IdentityUser> UserStore;
        protected UserManager<IdentityUser> UserManager;
        protected RoleStore<IdentityRole> RoleStore;
        protected RoleManager<IdentityRole> RoleManager;
        protected string CurrentUserId;


        protected BaseApiController()
        {
            Context = new ApplicationDbContext();

            UserStore = new UserStore<IdentityUser>();
            UserManager = new UserManager<IdentityUser>(UserStore);
            RoleStore = new RoleStore<IdentityRole>();
            RoleManager = new RoleManager<IdentityRole>(RoleStore);
            CurrentUserId = User.Identity.GetUserId();
        }


        protected override void Dispose(bool disposing)
        {

            Context.Dispose();
            base.Dispose(disposing);
        }
    }
}