using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Products.Commands.Add
{
    public class AddProductCommand : IBaseCommand<ProductResponseDto>, ICacheInvalidation
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        internal int UserId { get; set; }

        public IReadOnlyList<string> CacheKeys => new[]
        {
            "all-products",
            $"products-category-{CategoryId}"
        };
    }
}