using ECommerce.Business.Order.Dtos;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Order.Queries.GetMy
{
    public record GetMyOrdersQuery : ICacheableQuery<IReadOnlyList<OrderResponseDto>>
    {
        internal int UserId { get; set; }

        public string CacheKey => $"orders-user-{UserId}";
        public TimeSpan? Expiration => TimeSpan.FromMinutes(5);
    }
}