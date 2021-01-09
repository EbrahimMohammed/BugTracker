using System;
using System.ComponentModel.DataAnnotations;
using BugTracker.Core.Domain;
using BugTracker.Models;

namespace BugTracker.Dtos
{
    public class TicketDto 
    {

        public int Id { get; set; }

        public string Title { get; set; }


        public TicketStatusDto Status { get; set; }

        public PriorityDto Priority { get; set; }


        public DateTime? DueDate { get; set; }


        public UserDto AssignedDeveloper { get; set; }


        public TicketTypeDto TicketType { get; set; }



    }
}