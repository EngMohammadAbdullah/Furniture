// Copyright (c) 2016 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;
using Furniture.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Furniture.Test.EfHelpers
{
    public class EfInMemory
    {
        public static DbContextOptions<EntitiesContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an in-memory database
            var builder = new DbContextOptionsBuilder<EntitiesContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString()) //the database name is set to a unique Guid
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}