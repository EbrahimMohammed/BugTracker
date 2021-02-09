using System.Data.Entity.ModelConfiguration;
using BugTracker.Core.Domain;

namespace BugTracker.Persistance.EntityConfiguration
{
    public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {


        public OrganizationConfiguration()
        {

            Property(o => o.Name)
                .IsRequired();

            Property(o => o.ZipCode)
                .IsRequired();

            Property(o => o.AddressLine1)
                .IsRequired();


            HasMany(o => o.OrganizationUsers)
                .WithOptional(o => o.Organization)
                .HasForeignKey(u => u.OrganizationId);

            HasMany(o => o.Projects)
                .WithOptional(p => p.Organization)
                .HasForeignKey(p => p.OrganizationId);
            
            
            HasMany(o => o.Tickets)
                .WithOptional(t => t.Organization)
                .HasForeignKey(t => t.OrganizationId);


            

        }
    }
}