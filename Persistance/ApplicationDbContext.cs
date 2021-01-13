using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using BugTracker.Core.Domain;
using BugTracker.Models;
using BugTracker.Persistance.EntityConfiguration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugTracker.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Project> Projects { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<TicketStatus> TicketStatuses { get; set; }


        public DbSet<Priority> Priorities { get; set; }

        public DbSet<TicketType> TicketTypes { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Comments> Comments { get; set; }



        //public DbSet<UserExtension> UserExtensions { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {

            var AddedEntities = ChangeTracker.Entries<BaseEntity>().Where(E => E.State == EntityState.Added).ToList();
            try
            {

                AddedEntities.ForEach(E =>
                {
                    E.Entity.CreatedDate = DateTime.Now;
                    E.Entity.CreatedBy =  HttpContext.Current.User.Identity.GetUserId();
                    E.Entity.ModifiedBy = HttpContext.Current.User.Identity.GetUserId();

                });

                var ModifiedEntities = ChangeTracker.Entries<BaseEntity>().Where(E => E.State == EntityState.Modified)
                    .ToList();

                ModifiedEntities.ForEach(E => { E.Entity.ModifiedDate = DateTime.Now;
                    E.Entity.ModifiedBy = HttpContext.Current.User.Identity.GetUserId();
                });

                return base.SaveChanges();
            }
            catch 
            {
                throw new InvalidOperationException();
            }

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new ProjectConfigurations());
            modelBuilder.Configurations.Add(new TicketConfiguration());
            modelBuilder.Configurations.Add(new TicketTypeConfigurations());
            modelBuilder.Configurations.Add(new FileConfiguration());
            modelBuilder.Configurations.Add(new CommentsConfigurations());
       

            base.OnModelCreating(modelBuilder);
        }
    }
}