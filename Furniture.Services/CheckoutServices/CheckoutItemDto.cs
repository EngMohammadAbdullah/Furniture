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
        public string ItemName { get; set; }
        public string ImageUrl { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public decimal Price { get; set; }

        public short NumOfItems { get; set; }
        public string CustomerName { get; set; }

    }
}
