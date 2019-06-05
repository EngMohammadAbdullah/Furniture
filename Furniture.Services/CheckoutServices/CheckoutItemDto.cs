using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.CheckoutServices
{
    public class CheckoutItemDto
    {

        public Guid ItemKey { get; set; }
        public string ItemCategory { get; set; }
        public string ItemName { get; set; }
        public string ImageUrl { get; set; }
        public short NumOfItems { get; set; }
        public string CustomerName { get; set; }

    }
}
