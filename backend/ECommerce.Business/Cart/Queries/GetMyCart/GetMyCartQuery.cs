using ECommerce.Business.Cart.Dtos;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Cart.Queries.GetMyCart
{
    public record GetMyCartQuery : IUserSpecificCacheableQuery<IReadOnlyList<CartResponseDto>>
    {
        //internal int UserId { get; set; }

        //public string CacheKey => $"cart-user-{UserId}";

        //public TimeSpan? Expiration => TimeSpan.FromMinutes(5);
    }
}