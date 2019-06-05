using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furniture.Domain.Entities;
using Furniture.Domain.Entities.Core;
using Furniture.Domain.Entities.Extensions;

namespace Furniture.Domain.Services.Orders
{
    public class OrderService : IOrderService
    {



        public readonly IEntityRepository<Order> _orderRepository;
        public readonly IEntityRepository<Customer> _clientRepository;
        public readonly IEntityRepository<Item> _itemRepository;

        public OrderService(
            IEntityRepository<Order> orderRepository,
        IEntityRepository<Customer> clientRepository,
        IEntityRepository<Item> itemRepository
            )
        {
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
            _itemRepository = itemRepository;
        }
        public Order AddOrder(Order order)
        {
            var addedOrder = _orderRepository.Add(order) ? order : null;
            return _orderRepository.Save() != 0 ? addedOrder : null;

        }

        public Order AddOrderItems(List<Item> items, Order order)
        {
            var added = true;
            foreach (var item in items)
            {
                item.OrderKey = order.Key;
                added = _itemRepository.Add(item);
            }
            _itemRepository.Save();
            return added ? order : null;
        }

        public Order GetOrder(Guid key)
        {
            var order = _orderRepository.AllIncluding(x => x.Customer)
                 .FirstOrDefault(x => x.Key == key);
            return order;
        }

        public PaginatedList<Order> GetOrders(int pageIndex, int pageSize)
        {


            return _orderRepository.AllIncluding(x => x.Customer).
                OrderBy(x => x.CreatedOn)
                 .ToPaginatedList(pageIndex, pageSize);

            throw new NotImplementedException();
        }

        public PaginatedList<Order> GetOrders(int pageIndex, int pageSize,
            Guid customerKey)
        {
            var orders = _orderRepository.
                GetOrdersByCustomer(customerKey)
                .OrderBy(x => x.CreatedOn).ToPaginatedList(pageIndex, pageSize);
            return orders;

            throw new NotImplementedException();
        }

        public Order UpdateOrder(Order updateOrder)
        {
            throw new NotImplementedException();
        }
    }
}
