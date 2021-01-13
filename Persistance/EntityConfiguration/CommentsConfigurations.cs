using System.Data.Entity.ModelConfiguration;
using BugTracker.Core.Domain;

namespace BugTracker.Persistance.EntityConfiguration
{
    public class CommentsConfigurations : EntityTypeConfiguration<Comments>
    {


        public CommentsConfigurations()
        {

            Property(c => c.Comment)
                .HasMaxLength(1000);


            HasRequired(c => c.Ticket)
                .WithMany(t => t.Comments);

        }
    }
}