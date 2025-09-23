using ECommerce.Business.Order.Dtos;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Order.Queries.GetSoldProducts
{
    public record GetSoldProductsBySellerQuery : ICacheableQuery<IReadOnlyList<SoldProductDto>>
    {
        internal int SellerId { get; set; }

        public string CacheKey => $"sold-products-seller-{SellerId}";
        public TimeSpan? Expiration => TimeSpan.FromMinutes(5);
    }
}