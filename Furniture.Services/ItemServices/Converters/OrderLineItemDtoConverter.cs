using Furniture.BizLogic.Orders;
using Furniture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.ItemServices.Converters
{
    public static class OrderLineItemDtoConverter
    {
        public static OrderLineItem RetriveOrderLineItemDto(this OrderLineItemDto item)
        {

            return new OrderLineItem
            {

                SelectedItem = new Item
                {
                    Color = item.SelectedItem.ItemColor,
                    Height = item.SelectedItem.Height,
                    Name = item.SelectedItem.Name,
                    Price = item.SelectedItem.Price,
                    Width = item.SelectedItem.Width
                },
                NumItems = item.NumItems
            };
        }

    }
}
