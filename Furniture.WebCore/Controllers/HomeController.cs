using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Furniture.WebCore.Models;
using Furniture.Domain.Entities.Core;
using Furniture.Services.CustomerServices;
using Furniture.Services.CustomerServices.Concrete;

namespace Furniture.WebCore.Controllers
{
    public class HomeController : Controller
    {

        private readonly EntitiesContext _context;
        public HomeController(EntitiesContext context)
        {
            _context = context;
        }
        public IActionResult Index(SortFilterPageOptions options)
        {
            var listService = new ListCustomersService(_context);
            var customerList = listService.SortFilterPage(options).ToList();

            return View(new CustomerListCombinedDto(options, customerList));
        }

        public JsonResult GetFilterSearchContent(SortFilterPageOptions options)
        {
            var service = new CustomerFilterDropdownService(_context);
            return Json(service.GetFilterDropDownValues(options.FilterBy));

        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
