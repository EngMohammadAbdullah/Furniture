using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.ItemServices
{
    public enum ItemsFilterBy
    {
        [Display(Name = "All")]
        NoFilter = 0,
        [Display(Name = "By Colors...")]
        ByColors

    }

    public static class ItemsListDtoFilter
    {
        public static IQueryable<ItemListDto> FilterItemsBy(
            this IQueryable<ItemListDto> items, ItemsFilterBy filterBy, string filterValue)
        {

            if (string.IsNullOrEmpty(filterValue))
            {
                return items;
            }
            switch (filterBy)
            {
                case ItemsFilterBy.NoFilter:
                    return items;

                case ItemsFilterBy.ByColors:
                    var filterColor = filterValue;
                    return items.Where(x => x.ItemColor.StartsWith(filterColor));

                default:
                    throw new ArgumentOutOfRangeException
                   (nameof(filterBy), filterBy, null);
            }
        }
    }
}
