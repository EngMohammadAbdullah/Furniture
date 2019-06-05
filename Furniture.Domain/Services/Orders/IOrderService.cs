using Furniture.Domain.Entities;
using Furniture.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Services.Orders
{
    public interface IOrderService
    {
        Order AddOrder(Order order);
        Order GetOrder(Guid key);   
        Order UpdateOrder(Order updateOrder);
        Order AddOrderItems(List<Item> items,Order order);
        PaginatedList<Order> GetOrders(int pageIndex, int pageSize);
        PaginatedList<Order> GetOrders(int pageIndex, int pageSize, Guid customerKey);




    }
}
