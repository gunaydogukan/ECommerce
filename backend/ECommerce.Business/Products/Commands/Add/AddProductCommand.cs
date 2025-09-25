using ECommerce.Business.Products.Dtos;
using ECommerce.Business.Products.Queries.GetAllProducts;
using ECommerce.Business.Products.Queries.GetProductsByCategory;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Products.Commands.Add
{
    public record AddProductCommand : IBaseCommand<ProductResponseDto>, ICacheInvalidation
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        //internal int UserId { get; set; }

        public IReadOnlyList<Type> QueryTypes => new[]
        {
            typeof(GetAllProductsQuery),
            typeof(GetProductsByCategoryQuery)
        };
    }
}