using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.CustomerServices.QueryObjects
{

    public enum CustomesFiltersBy
    {
        [Display(Name = "All")]
        NoFilter = 0,
        [Display(Name = "By First Names...")]
        ByFirstNames,
        [Display(Name = "By Last Names...")]
        ByLastNames,
        [Display(Name = "By Phone...")]
        ByPhoneNumber
    }
    public static class CustomersFilterBy
    {
        public static IQueryable<CustomersListDto> FilterItemsBy(
            this IQueryable<CustomersListDto> customers, CustomesFiltersBy filterBy, string filterValue)
        {

            if (string.IsNullOrEmpty(filterValue))
            {
                return customers;
            }

            switch (filterBy)
            {
                case CustomesFiltersBy.NoFilter:
                    return customers;
                case CustomesFiltersBy.ByFirstNames:
                    var filterFirstname = filterValue;
                    return customers.Where(x => x.FisrtName.StartsWith(filterFirstname));
                case CustomesFiltersBy.ByLastNames:
                    var filterLastName = filterValue;
                    return customers.Where(x => x.LastName.StartsWith(filterLastName));
                case CustomesFiltersBy.ByPhoneNumber:
                    var filterPhoneNumber = filterValue;
                    return customers.Where(x => x.PhoneNumber.StartsWith(filterPhoneNumber));
                default:
                    throw new ArgumentOutOfRangeException
                  (nameof(filterBy), filterBy, null);
            }

        }
    }

}
