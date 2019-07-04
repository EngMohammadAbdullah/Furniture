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
    public static class CustomerJsonLoader
    {

        public static IEnumerable<Customer> LoadCustomers(string fileDir, string fileSearchString)
        {
            var filePath = GetJsonFilePath(fileDir, fileSearchString);
            var jsonDecoded = JsonConvert.DeserializeObject<ICollection<CustomerInfoJson>>(File.ReadAllText(filePath));

            var ordersDict = new Dictionary<Guid, Order>();
            //foreach (var customerInfoJson in jsonDecoded)
            //{
            //    foreach (var order in customerInfoJson.Orders)
            //    {
            //        if (!ordersDict.ContainsKey(order.Key))
            //            ordersDict[order.Key] = order;
            //    }
            //}

            return jsonDecoded.Select(x => CreateBookWithRefs(x, ordersDict));
        }

        private static Customer CreateBookWithRefs(CustomerInfoJson x, Dictionary<Guid, Order> ordersDict)
        {
            var customer = new Customer
            {

                FirstName = x.Name,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber


            };

            return customer;
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
