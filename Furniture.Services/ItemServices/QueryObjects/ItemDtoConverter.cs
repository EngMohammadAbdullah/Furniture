using Furniture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.ItemServices.QueryObjects
{
    public static class ItemDtoConverter
    {

        public static Item GetItem(this ItemListDto itemDto)
        {

            return new Item
            {
                Color = itemDto.ItemColor,
                Height = itemDto.Height,
                Name = itemDto.Name,
                Price = itemDto.Price,
                Width = itemDto.Width
            };

        }
    }
}
