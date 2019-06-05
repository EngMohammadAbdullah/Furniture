using Furniture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.DatabaseServices.Concrete
{
    public static class SpecialCustomer
    {
        public static Customer CreateSpetialCustomer()
        {
            var customer = new Customer
            {
                FirstName = "Mohammad",
                LastName = "Abdullah",
                Address = new Address { City = "Temse", StreetName = "Oeverstraat", Country = "Belgium" },
                Email = "Alkaser314@gmail.com",
                PhoneNumber = "0465134255"
            };
            //customer.Orders = new List<Order>
            //{
            //    new Order{Employee = new Employee { FirstName="Mohammad"} },
            //    new Order{Employee = new Employee { FirstName="Hasan"} }

            //    };
            return customer;


        }
    }
}

