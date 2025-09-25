using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery : ICacheableQuery<IReadOnlyList<ProductResponseDto>>
    {
        //public string CacheKey => "all-products";

        //public TimeSpan? Expiration => TimeSpan.FromMinutes(15);
    }
}