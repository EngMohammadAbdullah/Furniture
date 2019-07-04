using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furniture.BizLogic.Orders;
using Furniture.Domain.Entities.Core;
using Furniture.Services.CheckoutServices.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.WebCore.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly EntitiesContext _context;

        public CheckoutController(EntitiesContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listService = new CheckoutListService(_context, HttpContext.Request.Cookies);
            return View(listService.GetCheckoutList());
        }

        public IActionResult Buy(OrderLineItem itemToBuy)
        {
            var cookie = new CheckoutCookie(HttpContext.Request.Cookies, HttpContext.Response.Cookies);
            var service = new CheckoutCookieService(cookie.GetValue());
            service.AddLineItem(itemToBuy);
            cookie.AddOrUpdateCookie(service.EncodeForCookie());
            return RedirectToAction("Index");
        }

        public IActionResult AddToCart(OrderLineItem itemToBuy)
        {
            var cookie = new CheckoutCookie(HttpContext.Request.Cookies, HttpContext.Response.Cookies);
            var service = new CheckoutCookieService(cookie.GetValue());
            service.AddLineItem(itemToBuy);
            cookie.AddOrUpdateCookie(service.EncodeForCookie());
            return RedirectToAction("Index");
        }
    }
}