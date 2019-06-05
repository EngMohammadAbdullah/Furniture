using Furniture.Domain.Entities;
using Furniture.Domain.Entities.Core;
using Furniture.Domain.Services.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Test
{

    [TestClass]
    public class OrderTest
    {
        IEntityRepository<Order> _orderRepository;
        IEntityRepository<Customer> _clientRepository;
        IEntityRepository<Item> _itemRepository;
        EntitiesContext _context;
        OrderService orderService;
        public OrderTest()
        {
            _context = new EntitiesContext();
            _orderRepository = new EntityRepository<Order>(_context);
            _clientRepository = new EntityRepository<Customer>(_context);
            _itemRepository = new EntityRepository<Item>(_context);
            orderService = new OrderService(_orderRepository, _clientRepository,
               _itemRepository);
        }

        [TestMethod]
        public void Add_Test_Order()
        {
            var order = new Order()
            {
                Customer = new Customer { FirstName = "Mohammad Test" },
                Employee = new Employee { FirstName = "Employee Test", Email = "alkaser314@gmail.com", LastName = "Abdullah", PhoneNumber = "0465134255" }
            };

            var addedOrder = orderService.AddOrder(order);

            Assert.IsNotNull(addedOrder);



        }

        [TestMethod]
        public void Add_Items_To_Order()
        {
            var order = _orderRepository.AllIncluding(x => x.Items)
                .First();
            var items = new List<Item> {
                new Item{Color="Green"},
                new Item{Color="Red"}
            };

            orderService.AddOrderItems(items, order);

        }
        [TestMethod]
        public void Get_Order_By_Key()
        {
            var order = _orderRepository.AllIncluding(x => x.Items)
                         .First();

            Assert.AreEqual(orderService.GetOrder(order.Key), order);

        }
        [TestMethod]
        public void Get_Orders()
        {

            int pageIndex = 1;
            int pageSize = 4;

            var pages = orderService.GetOrders(pageIndex, pageSize);
            Assert.AreEqual(pageSize, pages.Count);

        }
    }
}
