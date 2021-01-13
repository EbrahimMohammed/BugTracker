using BugTracker.Models;

namespace BugTracker.Dtos
{
    public class CommentsDto
    {

        public string Comment { get; set; }

        public int TicketId { get; set; }

        public UserDto CreatedByTable { get; set; }



    }
}