using Furniture.Domain.Entities;
using Furniture.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.CustomerServices.Concrete
{
    public class AddNewCustomer
    {

        private readonly EntitiesContext _context;
        public AddNewCustomer(EntitiesContext context)
        {
            _context = context;
        }

        public void AddClient(Customer client)
        {
            _context.Add(client);
        }

    }
}
