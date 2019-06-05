using Furniture.Domain.Entities.Core;
using Furniture.Web.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Furniture.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            // container.RegisterType<EntitiesContext, HomeController>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }


    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EntitiesContext>(options => options.UseSqlServer(connection,
                b => b.MigrationsAssembly("DataLayer")));
        }


    }
}