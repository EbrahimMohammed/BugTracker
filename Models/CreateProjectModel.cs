using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class CreateProjectModel
    {

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }


        public List<string> UsersIds { get; set; }

    }
}