// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using Furniture.BizLogic.GenericInterfaces;
using Furniture.DataAccess.Orders;
using Furniture.Domain.Entities;

namespace Furniture.BizLogic.Orders.Concrete
{
    public class PlaceOrderAction :
        BizActionErrors,
        IBizAction<PlaceOrderInDto, Order>
    {
        private readonly IPlaceOrderDbAccess _dbAccess;

        public PlaceOrderAction(IPlaceOrderDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        /// <summary>
        /// This validates the input and if OK creates 
        /// an order and calls the _dbAccess to add to orders
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>returns an Order. Will be null if there are errors</returns>
        public Order Action(PlaceOrderInDto dto) //#D
        {                                     //#E
            if (!dto.LineItems.Any())                 //#E
            {                                         //#E
                AddError("No items in your basket."); //#E
                return null;                          //#E
            }                                         //#E

            var itemsDict =                                //#F
                _dbAccess.FindItemsByIdsWithPriceOffers    //#F
                     (dto.LineItems.Select(x => x.SelectedItem.Key));

            var order = new Order                          //#G
            {                                              //#G
                CustomerKey = dto.Customer.Key,                 //#G
                EmployeeKey = dto.Employee.Key,
                OrderedItems =                                //#G
                    FormLineItemsWithErrorChecking         //#G
                         (dto.LineItems, itemsDict)        //#G
            };                                             //#G

            if (!HasErrors)           //#H
                _dbAccess.Add(order); //#H

            return HasErrors ? null : order; //#I
        }

        private List<LineItem> FormLineItemsWithErrorChecking//#J
            (IEnumerable<OrderLineItem> lineItems,            //#J
             IDictionary<Guid, Item> itemsDict)                 //#J
        {
            var result = new List<LineItem>();
        

            foreach (var lineItem in lineItems)  //#K
            {
                if (!itemsDict.                             //#L
                    ContainsKey(lineItem.SelectedItem.Key))           //#L
                    throw new InvalidOperationException //#L
("An order failed because book, " +                     //#L
 $"id = {lineItem.SelectedItem.Name} was missing.");               //#L

                var item = itemsDict[lineItem.SelectedItem.Key];
                var itemPrice =
                   item.Price; //#M
                if (itemPrice <= 0)                         //#N
                    AddError(                               //#N
    $"Sorry, the book '{item.Name}' is not for sale.");    //#N
                else
                {
                    //Valid, so add to the order
                    result.Add(new LineItem
                    {
                        ChosenItem = item,
                        ItemPrice = item.Price,
                        Color = item.Color,
                        Height = item.Height,
                        Width = item.Width,
                        NumItems = lineItem.NumItems,
                        ItemKey = item.Key
                    });
                }
            }
            return result; //#p
        }
    }
}
