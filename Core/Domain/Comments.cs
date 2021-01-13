namespace BugTracker.Core.Domain
{
    public class Comments : BaseEntity
    {
        public string Comment { get; set; }

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }

    }
}