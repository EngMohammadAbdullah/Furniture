using Furniture.Domain.Entities.Core;
using Furniture.Domain.QueryObjects;
using Furniture.Services.ItemServices.QueryObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.ItemServices
{
    public class ListItemServices
    {
        private readonly EntitiesContext _context;

        public ListItemServices(EntitiesContext context)
        {
            _context = context;
        }

        public IQueryable<ItemListDto> GetSortedFilteredItems(SortFilterItemsOptions options)
        {
            var itemsQuery = _context.Items.AsNoTracking()
                .MapItemsToDtos().OrderItemssBy(options.OrderItemsByOptions)
                .FilterItemsBy(options.FilterItemsBy, options.FilterValue);

            options.SetupRestOfDto(itemsQuery);        //#F

            return itemsQuery.Page(options.PageNum - 1,  //#G
                                   options.PageSize);  //#G
            throw new NotImplementedException();
        }

        public ItemListDto GetItemBy(Guid itemKey)
        {

            return _context.Items.Where(i => i.Key.Equals(itemKey)).Single().MapItemToDto();
            throw new NotImplementedException();

        }

        public void SaveModifiedItem(ItemListDto modifiedDto)
        {
           
        }
    }
}
