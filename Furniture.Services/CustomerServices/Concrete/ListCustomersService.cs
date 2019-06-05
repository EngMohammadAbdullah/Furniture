using Furniture.Domain.Entities.Core;
using Furniture.Domain.QueryObjects;
using Furniture.Services.CustomerServices.QueryObjects;
using Furniture.Services.ItemServices.QueryObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.CustomerServices.Concrete
{
   public  class ListCustomersService
    {
        private readonly EntitiesContext _context;
        public ListCustomersService(EntitiesContext context)
        {
            _context = context;
        }

        public IQueryable<CustomersListDto> SortFilterPage(
          SortFilterPageOptions options)
        {
            var customersQuery = _context.Customers            //#A
                .AsNoTracking()                        //#B
                .MapCustomerToDto()                        //#C
                .OrderCustomersBy(options.OrderByOptions)  //#D
                .FilterItemsBy(options.FilterBy,       //#E
                               options.FilterValue);   //#E

            options.SetupRestOfDto(customersQuery);        //#F

            return customersQuery.Page(options.PageNum - 1,  //#G
                                   options.PageSize);  //#G

            throw new NotFiniteNumberException();
        }
        

    }
}
