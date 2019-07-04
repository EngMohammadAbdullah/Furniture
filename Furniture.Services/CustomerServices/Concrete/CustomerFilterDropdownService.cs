using Furniture.Domain.Entities.Core;
using Furniture.Services.CustomerServices.QueryObjects;
using Furniture.Services.ItemServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.CustomerServices.Concrete
{
    public class CustomerFilterDropdownService
    {

        private readonly EntitiesContext _context;
        public CustomerFilterDropdownService(EntitiesContext context)
        {
            _context = context;

        }

        public IEnumerable<DropdownTuple> GetFilterDropDownValues(CustomesFiltersBy filterBy)
        {
            switch (filterBy)
            {
                case CustomesFiltersBy.NoFilter:
                    return new List<DropdownTuple>();
                case CustomesFiltersBy.ByFirstNames:
                    return FormVotesDropDown();
                case CustomesFiltersBy.ByLastNames:
                    var result = _context.Customers.Select(c => c.LastName)
                        .Select(c => new DropdownTuple

                        {
                            Value = c.ToString(),
                            Text = c.ToString()
                        });

                    return result;
                case CustomesFiltersBy.ByPhoneNumber:
                    result = _context.Customers.Select(c => c.PhoneNumber)
                          .Select(c => new DropdownTuple

                          {
                              Value = c.ToString(),
                              Text = c.ToString()
                          });

                    return result;
                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);

            }
        }


        private static IEnumerable<DropdownTuple> FormVotesDropDown()
        {
            return new[]
            {
                new DropdownTuple {Value = "4", Text = "4 stars and up"},
                new DropdownTuple {Value = "3", Text = "3 stars and up"},
                new DropdownTuple {Value = "2", Text = "2 stars and up"},
                new DropdownTuple {Value = "1", Text = "1 star and up"},
            };
        }


    }
}
