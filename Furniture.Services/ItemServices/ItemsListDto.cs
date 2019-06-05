using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.ItemServices
{
    public class ItemListDto
    {

        public Guid ItemKey { get; set; }
        public String ItemColor { get; set; }
        public decimal  Price { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
   
    }
}
