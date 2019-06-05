using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace Furniture.Domain.Entities.Core
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext()
        {

        }

        public EntitiesContext(DbContextOptions<EntitiesContext> options)
            : base(options)
        {
            var dd = "";
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<Order>().HasQueryFilter(p => !p.SoftDeleted);

            //..Property(a => a.Items).IsConcurrencyToken()
            // .ValueGeneratedOnAddOrUpdate();

        }
        public const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDb1;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connStr = ConfigurationManager.ConnectionStrings["dbTest"].ConnectionString;

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<LineItem> LineItem { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Employee> Employees { get; set; }


    }
}