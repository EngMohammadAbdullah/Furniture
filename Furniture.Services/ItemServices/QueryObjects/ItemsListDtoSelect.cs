using Furniture.BizLogic.Orders;
using Furniture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace Furniture.Services.ItemServices.QueryObjects
{
    public static class ItemsListDtoSelect
    {
        public static IQueryable<ItemListDto>             //#A
          MapItemsToDtos(this IQueryable<Item> items)     //#A
        {
            return items.Select(p => new ItemListDto
            {
                Name = p.Name,
                ItemKey = p.Key,
                Height = p.Height,
                Width = p.Width,
                Price = p.Price
            });
        }


        public static ItemListDto MapItemToDto(this Item item)
        {

            return new ItemListDto
            {
                ItemKey = item.Key,
                Height = item.Height,
                ItemColor = item.Color,
                Name = item.Name,
                Price = item.Price,
                Width = item.Width

            };

        }

    }
}
