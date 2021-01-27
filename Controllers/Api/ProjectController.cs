using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using AutoMapper;
using BugTracker.Core;
using BugTracker.Core.Domain;
using BugTracker.Dtos;
using BugTracker.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace BugTracker.Controllers.Api
{

    [Authorize]
    public class ProjectController : BaseApiController
    {
      
    


        public IHttpActionResult GetProjects()
        {

            List<Project> projects;


            if (User.IsInRole(Roles.CanManageUsers))
            {

                projects = Context.Projects.Include(p => p.Users).ToList();

            }
            else
            {  
                
                projects = Context
                    .Projects.Include(p => p.Users)
                    .Where(p => p.Users.Select(u => u.Id).Contains(CurrentUserId))
                    .ToList();

            }

            var projectsDto = projects.Select(Mapper.Map<Project, ProjectDto>).ToList();

            return Ok(projectsDto);

        }


        [HttpPost]
        [Authorize(Roles= Roles.CanManageProjects)]
        public IHttpActionResult CreateProject(CreateProjectModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();



            var project = new Project
            {
                Name = model.Name,
                Description = model.Description

            };

            project.Users.Add(Context.Users.Single(u => u.Id == CurrentUserId));


            if (model.UsersIds != null)
            {
                if (model.UsersIds.Count > 0)
                {

                    var developers = Context
                        .Users
                        .Where(u => model.UsersIds.Contains(u.Id))
                        .ToList();

                    project.Users.AddRange(developers);
                }

            }


            Context.Projects.Add(project);

      
            Context.SaveChanges();

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

            var project = Context.Projects
                .Include(p => p.Users)
                .Single(p => p.Id == model.Id);

            
            var newDevelopers = new List<ApplicationUser>();


            if (model.UsersIds != null)
            {
                if (model.UsersIds.Count > 0)
                {
                    newDevelopers = Context
                            .Users
                            .Where(u => model.UsersIds.Contains(u.Id)).ToList();
                }
            }

            project.Users = newDevelopers;


            Context.SaveChanges();

            return Ok();
        }



    }
}
