using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furniture.Services.CheckoutServices.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.WebCore.Controllers
{
    public class CustomersController : Controller
    {


        public IActionResult ChooseCustomer(Guid customerKey)
        {

            var cookie = new CheckoutCookie(HttpContext.Request.Cookies, HttpContext.Response.Cookies);
            var service = new CheckoutCookieService(cookie.GetValue());
            service.AddCustomer(customerKey);
            cookie.AddOrUpdateCookie(service.EncodeForCookie());
            return RedirectToAction("Index", "Items");
        }


    }
}