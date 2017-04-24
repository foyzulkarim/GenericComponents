using System;
using System.Data.Entity;
using System.Linq;
using Model.Customers;

namespace Model
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext() : base("DefaultConnection")
        {
        }
        
        public override int SaveChanges()
        {
            var dbEntityEntries = ChangeTracker.Entries().Where(x => x.Entity is Entity);
            foreach (var entry in dbEntityEntries)
            {
                var entity = (Entity)entry.Entity;
                entity.Modified = DateTime.Now;
            }

            return base.SaveChanges();
        }

        public static BusinessDbContext Create()
        {
            return new BusinessDbContext();
        }

        // tables go here

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        public DbSet<Customer> Customers { get; set; }
    }
}