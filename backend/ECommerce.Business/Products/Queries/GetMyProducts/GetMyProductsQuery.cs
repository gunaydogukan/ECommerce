using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Products.Queries.GetProductsByUserId
{
    public record GetMyProductsQuery : IUserSpecificCacheableQuery<IReadOnlyList<ProductResponseDto>>
    {
        //internal int UserId { get; set; }

        //public string CacheKey => $"products-user-{UserId}";

        //public TimeSpan? Expiration => TimeSpan.FromMinutes(10);
    }
}