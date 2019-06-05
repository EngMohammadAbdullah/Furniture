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
        private const string SeedDataSearchName = "Customers.json";
        public const string SeedFileSubDirectory = "seedData";


        public static int SeedDatabase(this EntitiesContext context, string dataDirectory)
        {
            if (!(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                throw new InvalidOperationException("The database does not exist. If you are using Migrations then run PMC command update-database to create it");

            var numBooks = context.Customers.Count();
            if (numBooks == 0)
            {
                //the database is emply so we fill it from a json file
                var books = BookJsonLoader.LoadCustomers(Path.Combine(dataDirectory, SeedFileSubDirectory),
                    SeedDataSearchName).ToList();
                context.Customers.AddRange(books);
                context.SaveChanges();
                //We add this separately so that it has the highest Id. That will make it appear at the top of the default list
                context.Customers.Add(SpecialCustomer.CreateSpetialCustomer());
                context.SaveChanges();
                numBooks = books.Count + 1;
            }

            return numBooks;
        }

        public static void DevelopmentEnsureCreated(this EntitiesContext db)
        {
            db.Database.EnsureCreated();
        }


    }
}
