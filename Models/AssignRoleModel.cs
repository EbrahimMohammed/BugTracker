using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class AssignRoleModel
    {

        [Required]
        public string RoleId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}