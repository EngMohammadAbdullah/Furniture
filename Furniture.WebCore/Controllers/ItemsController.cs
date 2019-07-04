using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furniture.Domain.Entities;
using Furniture.Domain.Entities.Core;
using Furniture.Services.CheckoutServices.Concrete;
using Furniture.Services.ItemServices;
using Furniture.Services.ItemServices.Converters;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.WebCore.Controllers
{
    public class ItemsController : Controller
    {
        private readonly EntitiesContext _context;

        public ItemsController(EntitiesContext context)
        {
            _context = context;

        }


        public IActionResult Index(SortFilterItemsOptions options)
        {
            var listService = new ListItemServices(_context);
            var customerList = listService.GetSortedFilteredItems(options).ToList();

            return View(new ItemListCombinedDto(options, customerList));
        }
        [HttpGet]
        public IActionResult ChooseItems(Guid ChosenItemKey)
        {
            var listService = new ListItemServices(_context);
            OrderLineItemDto orderLineDto = new OrderLineItemDto
            {
                SelectedItem = listService.GetItemBy(ChosenItemKey),
                NumItems = 0

            };

            return View(orderLineDto);

        }

        [HttpPost, AcceptVerbs("Post")]
        public RedirectToActionResult ChooseItems(OrderLineItemDto modifiedDto)
        {
            var listService = new ListItemServices(_context);
            var cookie = new CheckoutCookie(HttpContext.Request.Cookies, HttpContext.Response.Cookies);
            var service = new CheckoutCookieService(cookie.GetValue());

            service.AddLineItem(modifiedDto.RetriveOrderLineItemDto());
            cookie.AddOrUpdateCookie(service.EncodeForCookie());
            return  RedirectToAction("Index");
        }

    
    }
}