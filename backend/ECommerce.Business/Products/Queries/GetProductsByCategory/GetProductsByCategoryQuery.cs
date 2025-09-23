using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Products.Queries.GetProductsByCategory
{
    public record GetProductsByCategoryQuery(int CategoryId) : ICacheableQuery<IReadOnlyList<ProductResponseDto>>
    {
        public string CacheKey => $"products-category-{CategoryId}";

        public TimeSpan? Expiration => TimeSpan.FromMinutes(10);
    }
}