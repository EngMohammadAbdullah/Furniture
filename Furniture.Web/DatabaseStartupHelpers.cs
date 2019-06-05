using Furniture.Domain.Entities.Core;
using Furniture.Services.DatabaseServices.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Furniture.Web
{
    public static class DatabaseStartupHelpers
    {

        private const string WwwRootDirectory = "wwwroot\\";

        public static string GetWwwRootPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), WwwRootDirectory);
        }

        //see https://github.com/aspnet/EntityFrameworkCore/issues/9033#issuecomment-317104564
        public static IWebHost MigrateDatabase(this IWebHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                using (var context = services.GetRequiredService<EntitiesContext>())
                {
                    try
                    {
                        context.Database.Migrate();
                    }
                    catch (Exception)
                    {
                        //var logger = services.GetRequiredService<ILogger<Program>>();
                        //logger.LogError(ex, "An error occurred while migrating the database.");
                        Console.WriteLine("An error occurred while migrating the database.");
                    }
                    try
                    {
                        context.SeedDatabase(GetWwwRootPath());
                    }
                    catch (Exception ex)
                    {
                        //var logger = services.GetRequiredService<ILogger<Program>>();
                        //logger.LogError(ex, "An error occurred while seeding the database.");
                        Console.WriteLine("An error occurred while seeding the database.");

                    }
                }
            }

            return webHost;
        }

        public static IWebHost SetupDevelopmentDatabase(this IWebHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                using (var context = services.GetRequiredService<EntitiesContext>())
                {
                    try
                    {
                        context.DevelopmentEnsureCreated();
                        context.SeedDatabase(GetWwwRootPath());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("An error occurred while setting upor seeding the development database.");
                    }
                }
            }

            return webHost;
        }
    }
}