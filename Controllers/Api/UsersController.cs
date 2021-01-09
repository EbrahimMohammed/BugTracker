using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using BugTracker.Core;
using BugTracker.Core.Domain;
using BugTracker.Dtos;
using BugTracker.Models;
using BugTracker.Persistance;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;


namespace BugTracker.Controllers.Api
{
    public class UsersController : ApiController
    {


        private readonly ApplicationDbContext _context;

        private UserStore<IdentityUser> _userStore;
        private UserManager<IdentityUser> _userManager;
        private RoleStore<IdentityRole> _roleStore;
        private RoleManager<IdentityRole> _roleManager;

          

        public UsersController()
        {
            _context = new ApplicationDbContext();

             _userStore = new UserStore<IdentityUser>();
             _userManager = new UserManager<IdentityUser>(_userStore);
             _roleStore = new RoleStore<IdentityRole>();
             _roleManager = new RoleManager<IdentityRole>(_roleStore);
        }

       
        


        // GET:url/api/users
        public IHttpActionResult GetUsers(string search = null)
        {


            var projectsQuery = _context.Users.AsQueryable();




            if (!search.IsNullOrWhiteSpace())
            {
                projectsQuery = projectsQuery.Where(u => u.UserName.Contains(search));
            }


            var projectsDto = projectsQuery
                                                    .ToList()
                                                    .Select(Mapper.Map<ApplicationUser, UserDto>);

            
            return Ok(projectsDto);

        }


        [System.Web.Http.Route("api/users/GetAvailableUsers")]
        public IHttpActionResult GetAvailableUsers(int id)
        {


            var project = _context
                .Projects
                .Include(p => p.Developers)
                .SingleOrDefault(p => p.Id == id);


            if (project == null)
                return NotFound();


            var availableUsers = new List<ApplicationUser>();

            if (project.Developers != null)
            {
                var unAvailableUsersIds = project.Developers.Select(d => d.Id);


                availableUsers = _context
                    .Users
                    .Where
                        (u => !(unAvailableUsersIds.Contains(u.Id)))
                    .ToList();

            }

            
            var userDto = Mapper.Map<List<ApplicationUser>, List<UserDto>>(availableUsers);


            return Ok(userDto);

        }
        
        
        
        [System.Web.Http.Route("api/users/GetProjectUsers")]
        public IHttpActionResult GetProjectUsers(int id)
        {

            var project = _context
                .Projects
                .Include(p => p.Developers)
                .SingleOrDefault(p => p.Id == id);

            if (project == null)
                return NotFound();

            var projectUsers = project.Developers.ToList();


            var userDto = Mapper.Map<List<ApplicationUser>, List<UserDto>>(projectUsers);


            return Ok(userDto);

        }


        [System.Web.Http.Route("api/users/GetUsersWithRoles")]
        public IHttpActionResult GetUsersWithRoles()
        {

            var usersDtos = _context.Users.ToList().Select(Mapper.Map<ApplicationUser, UserDto>).ToList();


            foreach (var user in usersDtos)
            {
                user.Role = _userManager.GetRoles(user.Id).FirstOrDefault();
            }




            return Ok(usersDtos);

        }


        //Get all users except admins and unassigned users
        [System.Web.Http.Route("api/users/GetAssignedUsers")]
        public IHttpActionResult GetAssignedUsers()
        {
            

            var adminRole = _roleManager.Roles.Single(r => r.Name == "Admin");



            var usersDtos = _context.Users
                .Include(u => u.Roles)
                .Where(u => u.Roles.Any() && u.Roles.FirstOrDefault().RoleId != adminRole.Id)
                .ToList()
                .Select(Mapper.Map<ApplicationUser, UserDto>)
                .ToList();



            foreach (var user in usersDtos)
            {
                user.Role = _userManager.GetRoles(user.Id).FirstOrDefault();
            }


            return Ok(usersDtos);


        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/users/AssignRole")]
        public IHttpActionResult AssignRole(AssignRoleModel model)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest();


            ////get old role of user if it exists
            //var oldRole = _userManager.GetRoles(model.UserId).FirstOrDefault();

            //var newRole = _roleManager.Roles.Single(r => r.Id == model.RoleId);


            ////remove old role
            //if (oldRole != null)
            //    _userManager.RemoveFromRole(model.UserId, oldRole);

            //// add new role
            //_userManager.AddToRole(model.UserId, newRole.Name);

            return Ok();

        }





    }

}
