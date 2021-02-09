using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugTracker.Models
{
    public class CreateUserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string RoleId { get; set; }

        [Required]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W_]).{6,}$")]

        public string Password { get; set; }

    }


    public class UserResponseModel
    {
        public string UserName { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }
    }


    public class CreateUserViewModel
    {
        public CreateUserModel CreateUserModel { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }

    }

}