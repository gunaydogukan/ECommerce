using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Products.Queries.GetProductsByUserId
{
    public class GetProductsByUserIdQuery : ICacheableQuery<IReadOnlyList<ProductResponseDto>>
    {
        // Dışarıdan set edilmez, sadece handler doldurur
        internal int UserId { get; set; }

        public string CacheKey => $"products-user-{UserId}";

        public TimeSpan? Expiration => TimeSpan.FromMinutes(10);
    }
}