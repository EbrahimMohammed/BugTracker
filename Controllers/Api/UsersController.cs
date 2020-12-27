using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BugTracker.Core;
using BugTracker.Core.Domain;
using BugTracker.Dtos;
using BugTracker.Models;
using BugTracker.Persistance;

namespace BugTracker.Controllers.Api
{
    public class UsersController : ApiController
    {


        private readonly ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }



        // GET:url/api/users
        public IHttpActionResult GetUsers()
        {


            var projectsDto = _context.Users.ToList().Select(Mapper.Map<ApplicationUser, UserDto>);


            return Ok(projectsDto);

        }


        [Route("api/users/GetAvailableUsers")]
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
        
        
        
        [Route("api/users/GetProjectUsers")]
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


    }
}
