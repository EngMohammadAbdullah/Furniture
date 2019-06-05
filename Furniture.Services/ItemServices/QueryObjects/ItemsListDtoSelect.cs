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
          MapBookToDto(this IQueryable<Item> items)     //#A
        {
            return items.Select(p => new ItemListDto
            {
                ItemKey = p.Key,
                Height = p.Height,
                Width = p.width,
                Price = p.Price
            });
        }

    }
}
