using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class CreateCommentModel
    {

        [Required]
        public int TicketId { get; set; }


        [Required]
        [MaxLength(1000)]
        public string Comment { get; set; }

    }
}