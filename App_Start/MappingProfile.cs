using AutoMapper;
using BugTracker.Core.Domain;
using BugTracker.Dtos;
using BugTracker.Models;


namespace BugTracker
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Project, ProjectDto>();
            Mapper.CreateMap<ProjectDto, Project>(); 
            
            
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<UserDto, ApplicationUser>();
        }
    }
}