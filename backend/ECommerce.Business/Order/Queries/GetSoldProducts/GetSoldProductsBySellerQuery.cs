using ECommerce.Business.Order.Dtos;
using ECommerce.Core.Caching;
using System.Text.Json.Serialization;

namespace ECommerce.Business.Order.Queries.GetSoldProducts
{
    public class GetSoldProductsBySellerQuery
        : ICacheableQuery<IReadOnlyList<SoldProductDto>>
    {
        internal int SellerId { get; set; }

        public string CacheKey => $"sold-products-seller-{SellerId}";
        public TimeSpan? Expiration => TimeSpan.FromMinutes(5);
    }
}