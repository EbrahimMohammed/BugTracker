using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugTracker.Models
{
    public class ManageUsersModel
    {

        public IEnumerable<IdentityRole> Roles { get; set; }

        [Required]
        public string RoleId { get; set; }
    }
}