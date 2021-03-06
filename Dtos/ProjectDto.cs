﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }


        public DateTime CreatedDate { get; set; }

        public List<UserDto> Users { get; set; }

    }
}