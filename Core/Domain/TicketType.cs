using System.Collections.Generic;

namespace BugTracker.Core.Domain
{
    public class TicketType
    {

        public int Id { get; set; }
        public string Type { get; set; }

        public List<Ticket> Tickets { get; set; }

    }
}