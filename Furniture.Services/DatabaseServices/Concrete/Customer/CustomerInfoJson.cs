using Furniture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.DatabaseServices.Concrete
{
    public class CustomerInfoJson
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}
