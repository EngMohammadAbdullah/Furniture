using Furniture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.CustomerServices.QueryObjects
{
   public static  class CustomerListDtoSelect
    {

        public static IQueryable<CustomersListDto> MapCustomerToDto
            (this IQueryable<Customer> customers)
        {

            return customers.Select(p => new CustomersListDto
            {
                CustomerKey = p.Key,
                FisrtName = p.FirstName,
                LastName = p.LastName,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email
            }
            );
        }
    }
}
