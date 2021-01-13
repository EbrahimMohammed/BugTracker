using System.Collections.Generic;

namespace BugTracker.Core.Domain
{
    public class File : BaseEntity
    {

        public string Name { get; set; }

        public string FilePath { get; set; }

        public string Description { get; set; }

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }
    }
}