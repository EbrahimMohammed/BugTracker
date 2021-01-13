using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BugTracker.Core.Domain;

namespace BugTracker.Persistance.EntityConfiguration
{
    public class TicketConfiguration : EntityTypeConfiguration<Ticket>
    {

        public TicketConfiguration()
        {
            Property(t => t.Title)
                .HasMaxLength(500)
                .IsRequired();


            HasRequired(t => t.Status)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.StatusId);

            HasOptional(t => t.AssignedDeveloper)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.AssignedDeveloperId);


            HasRequired(t => t.TicketType)
                .WithMany(tt => tt.Tickets)
                .HasForeignKey(t => t.TicketTypeId);



        }
    }
}