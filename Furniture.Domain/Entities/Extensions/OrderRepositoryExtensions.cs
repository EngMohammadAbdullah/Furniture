using Furniture.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Entities.Extensions
{
   public static class OrderRepositoryExtensions
    {

        public static IQueryable<Order> GetOrdersByCustomer(
            this IEntityRepository<Order> orderRepository,Guid customerKey)
        {

            return orderRepository.AllIncluding(x =>
            x.CustomerKey).Where(x => x.CustomerKey == customerKey);

        }
    }
}
