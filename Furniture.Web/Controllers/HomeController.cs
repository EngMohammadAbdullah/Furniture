using Furniture.Domain.Entities.Core;
using Furniture.Services.CustomerServices;
using Furniture.Services.CustomerServices.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Furniture.Web.Controllers
{
    public class HomeController : System.Web.Mvc.Controller
    {
        private readonly EntitiesContext _context;
        public HomeController(EntitiesContext context)
        {
            _context = context;
        }
        // GET: Home
        public ViewResult Index(SortFilterPageOptions options)
        {
            var listServices = new ListCustomersService(_context);
            var customerList =  listServices.SortFilterPage(options).ToList();
            return View(new CustomersListDto(options,customerList));
        }
    }
}