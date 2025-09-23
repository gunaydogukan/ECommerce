using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Business.Products.Commands.Update
{
    public record UpdateProductCommand([property: FromRoute] int Id) : IBaseCommand<ProductResponseDto>
    {
        public int? CategoryId { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public decimal? Price { get; init; }

        public IReadOnlyList<string> CacheKeys => new[]
        {
            "all-products",
            CategoryId is not null ? $"products-category-{CategoryId}" : ""
        }.Where(x => !string.IsNullOrEmpty(x)).ToList();
    }
}