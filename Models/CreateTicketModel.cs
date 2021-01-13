using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BugTracker.Core.Domain;

namespace BugTracker.Models
{
    public class CreateTicketViewModel
    {

        [DisplayName("Developers")]
        public IEnumerable<ApplicationUser> ProjectUsers { get; set; }

        public Ticket Ticket { get; set; }

        public IEnumerable<Priority> Priorities { get; set; }


        public IEnumerable<TicketType> TicketTypes { get; set; }
    }
}