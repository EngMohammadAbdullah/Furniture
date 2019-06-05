using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.ItemServices.QueryObjects
{

    public enum OrderByOptions
    {
        [Display(Name = "sort by...")]
        SimpleOrder = 0,
        [Display(Name = "Colors ↑")]
        ByVotes,
        [Display(Name = "Price ↓")]
        ByPriceLowestFirst,
        [Display(Name = "Price ↑")]
        ByPriceHigestFirst
    }

    public static class ItemListDtoSort
    {
        public static IQueryable<ItemListDto> OrderBooksBy
           (this IQueryable<ItemListDto> books,
            OrderByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptions.SimpleOrder:
                    return books.OrderByDescending(
                        x => x.ItemKey);
                case OrderByOptions.ByVotes:
                    return books.OrderByDescending(x =>
                        x.ItemColor);

                case OrderByOptions.ByPriceLowestFirst:
                    return books.OrderBy(x => x.Price);
                case OrderByOptions.ByPriceHigestFirst:
                    return books.OrderByDescending(
                        x => x.Price);
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(orderByOptions), orderByOptions, null);
            }
        }


    }
}
