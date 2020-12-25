using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } 

        public DateTime ModifiedDate { get; set; }

        public bool IsEnabled { get; set; } 

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}