using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.ItemServices.QueryObjects
{

    public enum OrderItemsByOptions
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
        public static IQueryable<ItemListDto> OrderItemssBy
           (this IQueryable<ItemListDto> books,
            OrderItemsByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderItemsByOptions.SimpleOrder:
                    return books.OrderByDescending(
                        x => x.ItemKey);
                case OrderItemsByOptions.ByVotes:
                    return books.OrderByDescending(x =>
                        x.ItemColor);

                case OrderItemsByOptions.ByPriceLowestFirst:
                    return books.OrderBy(x => x.Price);
                case OrderItemsByOptions.ByPriceHigestFirst:
                    return books.OrderByDescending(
                        x => x.Price);
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(orderByOptions), orderByOptions, null);
            }
        }


    }
}
