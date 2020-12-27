using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BugTracker.Core;
using BugTracker.Core.Domain;
using BugTracker.Dtos;
using BugTracker.Models;
using BugTracker.Persistance;
using Microsoft.Ajax.Utilities;

namespace BugTracker.Controllers.Api
{
    public class ProjectController : ApiController
    {
        private readonly ApplicationDbContext _context;



        public ProjectController()
        {
            _context = new ApplicationDbContext();
        }




        public IHttpActionResult GetProjects()
        {

            var projectsDto = _context.Projects.ToList().Select(Mapper.Map<Project, ProjectDto>);


            return Ok(projectsDto);

        }


        [HttpPost]
        public IHttpActionResult CreateProject(CreateProjectModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();



            var project = new Project
            {
                Name = model.Name,
                Description = model.Description

            };


            if (model.UsersIds != null)
            {
                if (model.UsersIds.Count > 0)
                {

                    var developers = _context
                                                        .Users
                                                        .Where(u => model.UsersIds.Contains(u.Id))
                                                        .ToList();


                    project.Developers.AddRange(developers);
                }

            }


            _context.Projects.Add(project);

      
            _context.SaveChanges();

            var projectDto = Mapper.Map<Project, ProjectDto>(project);

            projectDto.Id = project.Id;

            return Created(new Uri(Request.RequestUri + "/" + projectDto.Id), projectDto);


        }

        [HttpPost]
        [Route("api/project/updateProject")]
        public IHttpActionResult UpdateProject(UpdateProjectModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var project = _context.Projects
                                .Include(p => p.Developers)
                                .SingleOrDefault(p => p.Id == model.Id);

            if (project == null)
                return NotFound();


            var newDevelopers = new List<ApplicationUser>();


            if (model.UsersIds != null)
            {
                if (model.UsersIds.Count > 0)
                {
                    newDevelopers = _context
                            .Users
                            .Where(u => model.UsersIds.Contains(u.Id)).ToList();
                }
            }

            project.Developers = newDevelopers;


            _context.SaveChanges();

            return Ok();
        }



    }
}
