using System.Data.Entity.ModelConfiguration;
using BugTracker.Core.Domain;

namespace BugTracker.Persistance.EntityConfiguration
{
    public class TicketTypeConfigurations: EntityTypeConfiguration<TicketType>

    {
        public TicketTypeConfigurations()
        {
            Property(t => t.Type)
                .IsRequired();

        }

    }
}