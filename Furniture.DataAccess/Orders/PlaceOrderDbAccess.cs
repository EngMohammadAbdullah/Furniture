// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using Furniture.Domain.Entities;
using Furniture.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture.DataAccess.Orders
{
    public interface IPlaceOrderDbAccess
    {
        /// <summary>
        /// This finds any books that fits the BookIds given to it
        /// </summary>
        /// <param name="bookIds"></param>
        /// <returns>A dictionary with the BookId as the key, and the Book as the value</returns>
        IDictionary<Guid, Item> FindItemsByIdsWithPriceOffers(IEnumerable<Guid> itemIds);

        void Add(Order newOrder);
    }

    public class PlaceOrderDbAccess : IPlaceOrderDbAccess
    {
        private readonly EntitiesContext _context;

        public PlaceOrderDbAccess(EntitiesContext context)//#A
        {
            _context = context;
        }

        /// <summary>
        /// This finds any books that fits the BookIds given to it, with any optional promotion
        /// </summary>
        /// <param name="itemIds"></param>
        /// <returns>A dictionary with the BookId as the key, and the Book as the value</returns>
        public IDictionary<Guid, Item>
            FindItemsByIdsWithPriceOffers               //#B
               (IEnumerable<Guid> itemIds)               //#C
        {
            return _context.Items                      //#D
                .Where(x => itemIds.Contains(x.Key)) //#D

                // .Include(r => r.CustomerOrder)          
                //#E
                .ToDictionary(key => key.Key);       //#F
        }

        public void Add(Order newOrder)                 //#G
        {                                               //#G
            _context.Orders.Add(newOrder);              //#G
        }                                               //#G
    }
    /************************************************************
    #A All the BizDbAccess need the application's DbContext to access the database
    #B This method finds all the books that the user wants to buy
    #C The BizLogic hands it a collection of BookIds, which the checkout has provided
    #D This finds a book, if present, for each Id. 
    #E I include any optional promotion, as the BizLogic needs that for working out the price
    #F I return the result as a dictionary to make it easier for the BizLogic to look them up
    #G This method simply adds the new order that the BizlOgic built into the DbContext's Orders DbSet collection
     * **********************************************************/
}