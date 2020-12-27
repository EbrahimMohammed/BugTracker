using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BugTracker.Models;

namespace BugTracker.Core.Domain
{
    public class Project : BaseEntity
    {
        public Project()
        {
            Developers = new List<ApplicationUser>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<ApplicationUser> Developers { get; set; }


    }
}