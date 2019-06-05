using Furniture.Services.CustomerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.ItemServices.QueryObjects
{
    public enum OrderCustomersByOptions
    {
        [Display(Name = "sort by...")]
        SimpleOrder = 0,
        [Display(Name = "FirstNames ↑")]
        ByFirstNames,
        [Display(Name = "LastName ↑")]
        ByLastNames,

    }

    public static class CustomersListDtoSort
    {
        public static IQueryable<CustomersListDto> OrderCustomersBy
           (this IQueryable<CustomersListDto> customers,
            OrderCustomersByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderCustomersByOptions.SimpleOrder:
                    return customers.OrderByDescending(
                        x => x.CustomerKey);
                case OrderCustomersByOptions.ByFirstNames:
                    return customers.OrderByDescending(
                         x => x.FisrtName);
                case OrderCustomersByOptions.ByLastNames:
                    return customers.OrderByDescending(
                   x => x.LastName);
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(orderByOptions), orderByOptions, null);
            }
        }


    }
}
