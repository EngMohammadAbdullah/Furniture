using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.CustomerServices
{
    public class CustomersListDto
    {
        //private readonly SortFilterPageOptions options;
        //private readonly List<CustomersListDto> customerList;

        //public CustomersListDto(SortFilterPageOptions options, List<CustomersListDto> customerList)
        //{
        //    this.options = options;
        //    this.customerList = customerList;
        //}

        public Guid CustomerKey { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string  Address { get; set; }
        public override string ToString()
        {
            return $"{FisrtName} {LastName}";
        }
    }
}
