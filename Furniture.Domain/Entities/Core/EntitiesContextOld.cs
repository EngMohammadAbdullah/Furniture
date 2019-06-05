using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
//using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furniture.Domain.Entities.Core
{

    public class EntitiesContextOld : DbContext
    {



        public EntitiesContextOld() :
            base("dbTest")
        {
            
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EntitiesContextOld>());
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Order>().HasQueryFilter(p => !p.SoftDeleted);


        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["TestDb"].ConnectionString);
        //}
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Department> Departments { get; set; }

        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Client> Clients { get; set; }
        public IDbSet<Item> Items { get; set; }

        public IDbSet<Address> Addresses { get; set; }

        public IDbSet<Employee> Employees { get; set; }


    }
}