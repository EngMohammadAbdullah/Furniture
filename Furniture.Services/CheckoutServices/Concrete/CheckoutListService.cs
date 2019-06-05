// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Furniture.BizLogic.Orders;
using Furniture.Domain.Entities;
using Furniture.Domain.Entities.Core;
using Microsoft.AspNetCore.Http;

namespace Furniture.Services.CheckoutServices.Concrete
{
    public class CheckoutListService
    {
        private readonly EntitiesContext _context;
        private readonly IRequestCookieCollection _cookiesIn;

        public CheckoutListService(EntitiesContext context, IRequestCookieCollection cookiesIn)
        {
            _context = context;
            _cookiesIn = cookiesIn;
        }

        public ImmutableList<CheckoutItemDto> GetCheckoutList()
        {
            var cookieHandler = new CheckoutCookie(_cookiesIn);
            var service = new CheckoutCookieService(cookieHandler.GetValue());

            return GetCheckoutList(service.LineItems);
        }

        public ImmutableList<CheckoutItemDto> GetCheckoutList(IImmutableList<OrderLineItem> lineItems)
        {
            var result = new List<CheckoutItemDto>();
            foreach (var lineItem in lineItems)
            {
                result.Add(_context.Items.Select(book => new CheckoutItemDto
                {
                    //لازم عبيها هون 
                }).Single(y => y.ItemKey == lineItem.SelectedItem.Key));
            }
            return result.ToImmutableList();
        }
    }
}