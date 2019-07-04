using Furniture.Domain.Entities;
using Furniture.Domain.Entities.Core;
using Furniture.Services.ItemServices;
using Furniture.WebCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Furniture.Services.ItemServices.QueryObjects;

namespace Furniture.UnitTesting
{
    public class UnitTest1
    {
        EntitiesContext _context = new EntitiesContext();

        [Fact]
        public void Test1()
        {

            var controller = new ItemsController(_context);

            // Act
            var result = controller.Index(new Services.ItemServices.SortFilterItemsOptions());

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ItemListCombinedDto>(viewResult.ViewData.Model);
            Assert.Equal(3, model.ItemsList.Count());
        }

        [Fact]
        public void Test2()
        {

            //arrange 
            var Items = _context.Items.ToList().AsQueryable().MapItemsToDtos();
            var mockOrderService = new Mock<ListItemServices>();
            mockOrderService.Setup(x => x.GetSortedFilteredItems(new SortFilterItemsOptions()))
            .Returns(Items);
            var itemController = new ItemsController(_context);

            var result = itemController.Index(new SortFilterItemsOptions());
        }


        private IQueryable<ItemListDto> GetTestItems()
        {
            return new List<ItemListDto>
            {

                new ItemListDto{
                Name= "Chair",
                Height= 45,
                Width= 30,
                ItemColor= "Red",
                Price= 45
                },
                     new ItemListDto{
                Name= "Table",
                Height= 45,
                Width= 30,
                ItemColor= "Green",
                Price= 45
                }
                }.AsQueryable();

        }
    }
}

