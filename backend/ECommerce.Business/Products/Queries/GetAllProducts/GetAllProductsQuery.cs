using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : ICacheableQuery<IReadOnlyList<ProductResponseDto>>
    {
        public string CacheKey => "all-products";

        public TimeSpan? Expiration => TimeSpan.FromMinutes(15);
    }
}