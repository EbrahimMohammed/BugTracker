using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BugTracker.Core.Domain;

namespace BugTracker.Persistance.EntityConfiguration
{
    public class TicketStatusConfiguration : EntityTypeConfiguration<Priority>
    {

    }
}