using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : ICacheableQuery<ProductResponseDto?>
    {
        public int Id { get; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        public string CacheKey => $"product-{Id}";

        public TimeSpan? Expiration => TimeSpan.FromMinutes(30);
    }
}