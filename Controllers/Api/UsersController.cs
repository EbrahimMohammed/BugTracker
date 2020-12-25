using System;
using System.Collections.Generic;
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


    }
}
