using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.ItemServices
{
   public  class OrderLineItemDto
    {
        public ItemListDto SelectedItem { get; set; }

        public short NumItems { get; set; }

    }
}
