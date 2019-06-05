// Copyright (c) 2016 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Runtime.CompilerServices;

using Furniture.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Furniture.Test.Helpers;

namespace Furniture.Test.EfHelpers
{
    public static class EfOptionsHelper
    {
        /// <summary>
        /// This creates a new and seeded database every time, with a name that is unique to the class+method that called it
        /// </summary>
        public static DbContextOptions<EntitiesContext> NewMethodUniqueDatabaseSeeded4Books<T>(this T testClass,
             [CallerMemberName] string methodName = "")
        {
            var optionsBuilder = SetupOptionsWithCorrectConnection(testClass, methodName);
            EnsureDatabaseIsCreatedAndSeeded(optionsBuilder.Options, true, true);

            return optionsBuilder.Options;
        }

        /// <summary>
        /// This creates a new and seeded database if not already present, with a name that is unique to the class+method that called it
        /// </summary>
        public static DbContextOptions<EntitiesContext> ClassUniqueDatabaseSeeded4Books<T>(this T testClass)
        {
            var optionsBuilder = SetupOptionsWithCorrectConnection(testClass);
            EnsureDatabaseIsCreatedAndSeeded(optionsBuilder.Options, true, false);

            return optionsBuilder.Options;
        }

        /// <summary>
        /// This creates a new and seeded database every time, with a name that is unique to the class that called it
        /// </summary>
        public static DbContextOptions<EntitiesContext> NewClassUniqueDatabaseSeeded4Books<T>(this T testClass)
        {
            var optionsBuilder = SetupOptionsWithCorrectConnection(testClass);
            EnsureDatabaseIsCreatedAndSeeded(optionsBuilder.Options, true, true);

            return optionsBuilder.Options;
        }


        //--------------------------------------------------------------------
        //private methods
        private static DbContextOptionsBuilder<EntitiesContext> SetupOptionsWithCorrectConnection<T>(T testClass, string methodName = null)
        {
            var connection = testClass.GetUniqueDatabaseConnectionString(methodName);
            var optionsBuilder =
                new DbContextOptionsBuilder<EntitiesContext>();

            optionsBuilder.UseSqlServer(connection);
            return optionsBuilder;
        }

        private static void EnsureDatabaseIsCreatedAndSeeded(DbContextOptions<EntitiesContext> options, bool seedDatabase, bool deleteDatabase)
        {
            using (var context = new EntitiesContext(options))
            {
                if (deleteDatabase)
                    context.Database.EnsureDeleted();

                if (context.Database.EnsureCreated() && seedDatabase)
                    context.SeedDatabaseFourBooks();
            }
        }
    }
}