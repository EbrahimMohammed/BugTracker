using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugTracker.Dtos
{
    public class UserDto
    {

        public string Id { get; set; }


        public string UserName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }


    }
}