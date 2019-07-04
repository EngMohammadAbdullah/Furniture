using Furniture.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.DatabaseServices.Concrete
{
    public static class SetupHelpers
    {
        private const string SeedCustomerDataSearchName = "Customers.json";
        private const string SeedItemDataSearchName = "Items.json";
        public const string SeedFileSubDirectory = "seedData";


        public static void SeedDatabase(this EntitiesContext context, string dataDirectory)
        {
            if (!(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                throw new InvalidOperationException("The database does not exist. If you are using Migrations then run PMC command update-database to create it");

            AddCutomers(context, dataDirectory);
            AddItems(context, dataDirectory);
        }

        private static int AddCutomers(EntitiesContext context, string dataDirectory)
        {

            var numCustomers = context.Customers.Count();
            if (numCustomers == 0)
            {
                //the database is emply so we fill it from a json file
                var customers = CustomerJsonLoader.LoadCustomers(Path.Combine(dataDirectory, SeedFileSubDirectory),
                    SeedCustomerDataSearchName).ToList();
                context.Customers.AddRange(customers);
                context.SaveChanges();
                //We add this separately so that it has the highest Id. That will make it appear at the top of the default list
                context.Customers.Add(SpecialCustomer.CreateSpetialCustomer());
                context.SaveChanges();
                numCustomers = customers.Count + 1;
            }

            return numCustomers;
        }

        private static int AddItems(EntitiesContext context, string dataDirectory)
        {
            var numItems = context.Items.Count();
            if (numItems == 0)
            {
                //the database is emply so we fill it from a json file
                var items = ItemJsonLoader.LoadItems(Path.Combine(dataDirectory, SeedFileSubDirectory),
                    SeedItemDataSearchName).ToList();
                context.Items.AddRange(items);
                context.SaveChanges();
            }
            return numItems;
        }

        public static void DevelopmentEnsureCreated(this EntitiesContext db)
        {
            db.Database.EnsureCreated();
        }


    }
}
