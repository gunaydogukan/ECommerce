using ECommerce.Business.Order.Dtos;
using ECommerce.Business.OrderItem.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Order.Commands.Add
{
    public class AddOrderCommand : IBaseCommand<OrderResponseDto>, ICacheInvalidation
    {
        internal int UserId { get; set; }
        internal int? SellerId { get; set; }
        public List<OrderItemCreateDto> Items { get; set; } = new();

        public IReadOnlyList<string> CacheKeys
        {
            get
            {
                var keys = new List<string> { $"orders-user-{UserId}" };

                if (SellerId.HasValue)
                    keys.Add($"sold-products-seller-{SellerId.Value}");

                return keys;
            }
        }
    }
}