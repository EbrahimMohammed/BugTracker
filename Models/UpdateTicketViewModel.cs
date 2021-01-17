using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using BugTracker.Core.Domain;

namespace BugTracker.Models
{
    public class UpdateTicketViewModel
    {

        [DisplayName("Assigned developer")]
        public IEnumerable<ApplicationUser> ProjectUsers { get; set; }

        public Ticket Ticket { get; set; }

        public IEnumerable<Priority> Priorities { get; set; }


        public IEnumerable<TicketType> TicketTypes { get; set; }

        public IEnumerable<TicketStatus> TicketStatus { get; set; }

        public FileModel FileModel  { get; set; }


        public CommentsModel CommentsModel { get; set; }
        




    }

    public class CommentsModel
    {

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }


    }

    public class FileModel

    {
        [MaxLength(1000)]
        [Required]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.pdf|.txt)$", ErrorMessage = "Unsupported file type")]
        public HttpPostedFileBase FileUpload { get; set; }


        [Required]
        public int TicketId { get; set; }

        public string FilePath { get; set; }




    }
}