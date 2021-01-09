using System.Collections.Generic;

namespace BugTracker.Core.Domain
{
    public class  TicketStatus : BaseEntity
    {
        public string Name { get; set; }

        public List<Ticket> Tickets { get; set; }


    }
}