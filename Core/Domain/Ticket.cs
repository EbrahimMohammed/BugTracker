using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Models;

namespace BugTracker.Core.Domain
{
    public class Ticket : BaseEntity
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public TicketStatus Status { get; set; }

        public Priority Priority { get; set; }

        [Required]
        public int PriorityId { get; set; }

        public int StatusId { get; set; }

        public DateTime? DueDate { get; set; }

        public string AssignedDeveloperId { get; set; }


        public ApplicationUser AssignedDeveloper { get; set; }


        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        public int TicketTypeId { get; set; }

        public TicketType TicketType { get; set; }


        public List<File> Files { get; set; }


        public List<Comments> Comments { get; set; }


    }

}