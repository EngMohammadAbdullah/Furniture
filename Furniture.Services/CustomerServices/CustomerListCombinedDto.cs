using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.CustomerServices
{
    public  class CustomerListCombinedDto
    {
        public CustomerListCombinedDto(SortFilterPageOptions sortFilterPageData, IEnumerable<CustomersListDto> customersList)
        {
            SortFilterPageData = sortFilterPageData;
            CustomersList = customersList;
        }
        public SortFilterPageOptions SortFilterPageData { get; private set; }

        public IEnumerable<CustomersListDto> CustomersList { get; private set; }
    }
}
