using Furniture.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.ItemServices
{
   public  class ItemListCombinedDto
    {
        public ItemListCombinedDto(PaginatedList<ItemListDto> sortFilterPageData, IEnumerable<ItemListDto> itemsList)
        {
            SortFilterPageData = sortFilterPageData;
            ItemsList = itemsList;
        }

        public PaginatedList<ItemListDto> SortFilterPageData { get; private set; }

        public IEnumerable<ItemListDto> ItemsList { get; private set; }
    }
}
