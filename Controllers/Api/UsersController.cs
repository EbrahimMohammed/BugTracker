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
    public class UsersController : BaseApiController
    {

        
        

        // GET:url/api/users
        public IHttpActionResult GetUsers(string search = null)
        {
            var usersDtos = Enumerable.Empty<UserDto>();

            var organization = Context.Users
                .Include(u => u.Organization)
                .Single(u => u.Id == CurrentUserId)
                .Organization;

            if (organization != null)
            {
                Context.Entry(organization).Collection(o => o.OrganizationUsers).Load();

                var usersQuery = organization
                    .OrganizationUsers
                    .Where(u => u.Id != CurrentUserId)
                    .AsQueryable();

                if (!search.IsNullOrWhiteSpace())
                {
                    usersQuery = usersQuery.Where(u => u.UserName.Contains(search));
                }

                usersDtos = usersQuery
                    .ToList()
                    .Select(Mapper.Map<ApplicationUser, UserDto>);
            }

            
            return Ok(usersDtos);
        }


        [System.Web.Http.Route("api/users/GetAvailableUsers")]
        public IHttpActionResult GetAvailableUsers(int id)
        {

            var project = Context
                .Projects
                .Include(p => p.Users)
                .SingleOrDefault(p => p.Id == id);


            if (project == null)
                return NotFound();


            var availableUsers = new List<ApplicationUser>();

            if (project.Users != null)
            {
                var unAvailableUsersIds = project.Users.Select(d => d.Id);


                availableUsers = Context
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

            var project = Context
                .Projects
                .Include(p => p.Users)
                .SingleOrDefault(p => p.Id == id);

            if (project == null)
                return NotFound();

            var projectUsers = project.Users.ToList();


            var userDto = Mapper.Map<List<ApplicationUser>, List<UserDto>>(projectUsers);


            foreach (var user in userDto)
            {
                user.Role = UserManager.GetRoles(user.Id).FirstOrDefault();
            }


            return Ok(userDto);

        }


        [System.Web.Http.Route("api/users/GetUsersWithRoles")]
        public IHttpActionResult GetUsersWithRoles()
        {
            var usersDtos = new List<UserDto>();

            var organization = Context.Users
                .Include(u => u.Organization)
                .Single(u => u.Id == CurrentUserId)
                .Organization;


            if (organization != null)
            {

               usersDtos = UsersWithRoles(organization.Id);
            }


            return Ok(usersDtos);

        }


        //Get all users except admins and unassigned users
        [System.Web.Http.Route("api/users/GetAssignedUsers")]
        public IHttpActionResult GetAssignedUsers()
        {
            var adminRole = RoleManager.Roles.Single(r => r.Name == "Admin");


            var usersDtos = Context.Users
                .Include(u => u.Roles)
                .Where(u => u.Roles.Any() && u.Roles.FirstOrDefault().RoleId != adminRole.Id)
                .ToList()
                .Select(Mapper.Map<ApplicationUser, UserDto>)
                .ToList();


            foreach (var user in usersDtos)
            {
                user.Role = UserManager.GetRoles(user.Id).FirstOrDefault();
            }


            return Ok(usersDtos);


        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/users/AssignRole")]
        public IHttpActionResult AssignRole(AssignRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //get old role of user if it exists
            var oldRole = UserManager.GetRoles(model.UserId).FirstOrDefault();

            var newRole = RoleManager.Roles.Single(r => r.Id == model.RoleId);


            //remove old role
            if (oldRole != null)
                UserManager.RemoveFromRole(model.UserId, oldRole);

            // add new role
            UserManager.AddToRole(model.UserId, newRole.Name);

            return Ok();

        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Http.Route("api/users/CreateUser")]
        public IHttpActionResult CreateUser(CreateUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var store = new UserStore<ApplicationUser>(Context);

            var manager = new UserManager<ApplicationUser, string>(store);

            var role = RoleManager.Roles.SingleOrDefault(r => r.Id == model.RoleId);

            if (role == null)
                return NotFound();

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                OrganizationId = Context.Users.Single(u => u.Id == CurrentUserId).OrganizationId
            };

            
            var result = manager.Create(user, model.Password);

            if (!result.Succeeded)
                return GetErrorResult(result);


                
            result = manager.AddToRole(user.Id, role.Name);

            if (!result.Succeeded)
               return GetErrorResult(result);

            var userResponse = new UserResponseModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Role = role.Name

            };
            
            return Created(new Uri(Request.RequestUri + "/" + user.Id), userResponse);
        }




        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            if (ModelState.IsValid)
            {
                // No ModelState errors are available to send, so just return an empty BadRequest.
                return BadRequest();
            }

            return BadRequest(ModelState);
        }



        public List<UserDto> UsersWithRoles(int organizationId)
        {
            var usersWithRoles = (from user in Context.Users.Where(u => u.OrganizationId == organizationId && u.Id != CurrentUserId)
                select new
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    RoleNames = (from userRole in user.Roles
                        join role in Context.Roles on userRole.RoleId equals role.Id
                        select role.Name).ToList()})
                .ToList().Select(p => new UserDto()

            {
                Id = p.UserId,
                UserName = p.Username,
                Email = p.Email,
                Role = p.RoleNames.FirstOrDefault()
            });

            return usersWithRoles.ToList();
        }



    }

}
