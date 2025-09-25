using ECommerce.Business.Cart.Queries.GetMyCart;
using ECommerce.Business.Order.Dtos;
using ECommerce.Business.Order.Queries.GetMy;
using ECommerce.Business.Order.Queries.GetSoldProducts;
using ECommerce.Business.OrderItem.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Order.Commands.Add
{
    public record AddOrderCommand : IBaseCommand<OrderResponseDto>, ICacheInvalidation
    {
        public List<OrderItemCreateDto> Items { get; set; } = new();

        public IReadOnlyList<Type> QueryTypes => new[]
        {
            typeof(GetMyOrdersQuery),
            typeof(GetMySoldProductsBySellerQuery),
            typeof(GetMyCartQuery)
        };
    }
}