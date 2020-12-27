using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class UpdateProjectModel
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        public string Description { get; set; }


        public List<string> UsersIds { get; set; }

    }
}