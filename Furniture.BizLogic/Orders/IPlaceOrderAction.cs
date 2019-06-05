
using Furniture.BizLogic.GenericInterfaces;
using Furniture.Domain.Entities;

namespace Furniture.BizLogic.Orders
{
    public interface IPlaceOrderAction : IBizAction<PlaceOrderInDto, Order> { }
}