using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Models;

namespace BugTracker.Core.Domain
{
    public class BaseEntity 
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
            IsEnabled = true;
        }
        [Required]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } 

        public DateTime ModifiedDate { get; set; }

        public bool IsEnabled { get; set; } 

        public bool IsDeleted { get; set; }

        [ForeignKey("CreatedByTable")]
        public string CreatedBy { get; set; }

        [ForeignKey("ModifiedByTable")]
        public string ModifiedBy { get; set; }
        public ApplicationUser CreatedByTable { get; set; }

        public ApplicationUser ModifiedByTable { get; set; }
    }
}