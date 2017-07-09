using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMSLionel.Models
{
    public class ApplicationDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<CMSLionel.Models.Container> Containers { get; set; }

        public System.Data.Entity.DbSet<CMSLionel.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<CMSLionel.Models.Ship> Ships { get; set; }

        public System.Data.Entity.DbSet<CMSLionel.Models.Shipyard> Shipyards { get; set; }

        public System.Data.Entity.DbSet<CMSLionel.Models.Schedule> Schedules { get; set; }
    }
}
