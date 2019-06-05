// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using Furniture.Domain.Entities;
using System;
using System.Collections.Immutable;

namespace Furniture.BizLogic.Orders
{
    public class PlaceOrderInDto
    {

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }

        public IImmutableList<OrderLineItem> LineItems { get; private set; }
        public Order Order { get; private set; }

        public PlaceOrderInDto(IImmutableList<OrderLineItem> lineItems, Order order)
        {
            LineItems = lineItems;
            Order = order;
        }
    }
}