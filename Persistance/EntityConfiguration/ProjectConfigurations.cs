using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BugTracker.Core.Domain;

namespace BugTracker.Persistance.EntityConfiguration
{
    public class ProjectConfigurations : EntityTypeConfiguration<Project>
    {

        public ProjectConfigurations()
        {

            Property(p => p.Name)
                .HasMaxLength(500)
                .IsRequired();


            HasMany(p => p.Users)
                .WithMany(a => a.Projects)
                .Map(cs =>
                {
                    cs.MapLeftKey("ProjectId");
                    cs.MapRightKey("UserId");
                    cs.ToTable("ProjectUserMapping");
                });

            HasMany(p => p.Tickets)
                .WithRequired(t => t.Project)
                .HasForeignKey(p => p.ProjectId);
 
        }
    }
}