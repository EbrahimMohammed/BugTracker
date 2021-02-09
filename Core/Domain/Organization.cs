using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BugTracker.Models;

namespace BugTracker.Core.Domain
{
    public class Organization: BaseEntity
    {


        public string Name { get; set; }

        [MinLength(5)]
        public string ZipCode  { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public List<ApplicationUser> OrganizationUsers { get; set; }

        public List<Project> Projects { get; set; }

        public List<Ticket> Tickets { get; set; }


    }
}