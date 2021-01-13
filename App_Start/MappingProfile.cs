using AutoMapper;
using BugTracker.Core.Domain;
using BugTracker.Dtos;
using BugTracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;


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
            
            
            Mapper.CreateMap<Ticket, TicketDto>();

            Mapper.CreateMap<Priority, PriorityDto>();

            Mapper.CreateMap<TicketStatus, TicketStatusDto>();

            Mapper.CreateMap<TicketType, TicketTypeDto>();


            Mapper.CreateMap<IdentityUserRole, RoleDto>();

            Mapper.CreateMap<File, FileDto>();

            Mapper.CreateMap<Comments, CommentsDto>();



        }
    }
}