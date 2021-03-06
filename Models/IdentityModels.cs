﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BugTracker.Core.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugTracker.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            Projects = new List<Project>();
        }

        public List<Project> Projects { get; set; }


        public List<Ticket> DeveloperTickets { get; set; }

        public List<Ticket> TesterTickets { get; set; }

        public List<Ticket> CreatorTickets { get; set; }

        public int? OrganizationId { get; set; }

        public Organization Organization { get; set; }

            
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}