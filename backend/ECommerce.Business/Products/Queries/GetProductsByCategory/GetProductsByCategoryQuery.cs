using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQuery : ICacheableQuery<IReadOnlyList<ProductResponseDto>>
    {
        public int CategoryId { get; }

        public GetProductsByCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }

        // Cache key → kategori bazlı
        public string CacheKey => $"products-category-{CategoryId}";

        // Örnek: 10 dk cache
        public TimeSpan? Expiration => TimeSpan.FromMinutes(10);
    }
}