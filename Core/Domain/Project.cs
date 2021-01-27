using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BugTracker.Models;

namespace BugTracker.Core.Domain
{
    public class Project : BaseEntity
    {
        public Project()
        {
            Users = new List<ApplicationUser>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<ApplicationUser> Users { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}