using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(int Id) : ICacheableQuery<ProductResponseDto?>
    {
        public string CacheKey => $"product-{Id}";

        public TimeSpan? Expiration => TimeSpan.FromMinutes(30);
    }
}