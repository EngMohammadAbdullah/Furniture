using Furniture.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.DatabaseServices.Concrete
{
    public static class ItemJsonLoader
    {
        public static IEnumerable<Item> LoadItems(string fileDir, string fileSearchString)
        {
            var filePath = GetJsonFilePath(fileDir, fileSearchString);
            var jsonDecoded = JsonConvert.DeserializeObject<ICollection<ItemsInfoJson>>(File.ReadAllText(filePath));

            var ordersDict = new Dictionary<Guid, Order>();
            return jsonDecoded.Select(x => CreateItemWithRefs(x, ordersDict));
        }

        private static Item CreateItemWithRefs(ItemsInfoJson x,
            Dictionary<Guid, Order> ordersDict = null)
        {
            var item = new Item
            {
                Color = x.Color,
                Height = x.Height,
                Name = x.Name,
                Price = x.Price,
                Width = x.Width
            };
            return item;
        }

        private static string GetJsonFilePath(string fileDir, string searchPattern)
        {
            var fileList = Directory.GetFiles(fileDir, searchPattern);

            if (fileList.Length == 0)
                throw new FileNotFoundException($"Could not find a file with the search name of {searchPattern} in directory {fileDir}");

            //If there are many then we take the most recent
            return fileList.ToList().OrderBy(x => x).Last();
        }

    }
}
