using Microsoft.AspNet.Identity.EntityFramework;
using OfferSpace.BL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.DAL.Core
{
    public class OfferSpaceContext : IdentityDbContext<User>
    {
        public OfferSpaceContext()
            : base("OfferSpaceContext")
        {
        }

        public static OfferSpaceContext Create()
        {
            return new OfferSpaceContext();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestCustomer> RequestCustomers { get; set; }
        public DbSet<RequestCustomerDiscusion> RequestCustomerDiscusions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>().Ignore(c => c.AccessFailedCount)
                                   .Ignore(c => c.LockoutEnabled)
                                   .Ignore(c => c.LockoutEndDateUtc)
                                   .Ignore(c => c.TwoFactorEnabled);

        }
    }
}
