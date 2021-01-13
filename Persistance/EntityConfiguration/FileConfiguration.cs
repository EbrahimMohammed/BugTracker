using System.Data.Entity.ModelConfiguration;
using BugTracker.Core.Domain;

namespace BugTracker.Persistance.EntityConfiguration
{
    public class FileConfiguration: EntityTypeConfiguration<File>

    {
        public FileConfiguration()
        {


            Property(f => f.FilePath)
                .HasMaxLength(500);

            Property(t => t.Description)
                .HasMaxLength(1000);

            HasRequired(f => f.Ticket)
                .WithMany(t => t.Files)
                .HasForeignKey(f => f.TicketId)
                .WillCascadeOnDelete(false);

        }

    }
}