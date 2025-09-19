using ECommerce.Business.Order.Dtos;
using ECommerce.Core.Caching;
using System.Text.Json.Serialization;

namespace ECommerce.Business.Order.Queries.GetSoldProducts
{
    public class GetSoldProductsBySellerQuery
        : ICacheableQuery<IReadOnlyList<SoldProductDto>>
    {
        [JsonIgnore]
        public int SellerId { get; }

        public GetSoldProductsBySellerQuery(int sellerId)
        {
            SellerId = sellerId;
        }

        public string CacheKey => $"sold-products-seller-{SellerId}";
        public TimeSpan? Expiration => TimeSpan.FromMinutes(5);
    }
}