using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BugTracker.Persistance;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugTracker
{
    public class Helper
    {

        private readonly ApplicationDbContext _context;

        private static UserStore<IdentityUser> _userStore;
        private static UserManager<IdentityUser> _userManager;
        private static RoleStore<IdentityRole> _roleStore;
        private static RoleManager<IdentityRole> _roleManager;

       

        public Helper()
        {
            _context = new ApplicationDbContext();

            _userStore = new UserStore<IdentityUser>();
            _userManager = new UserManager<IdentityUser>(_userStore);
            _roleStore = new RoleStore<IdentityRole>();
            _roleManager = new RoleManager<IdentityRole>(_roleStore);
        }




        public static  string GetUserRole(string userId)
        {

            var roles = _userManager.GetRoles(userId);

            return roles.FirstOrDefault();
        }

    }
}