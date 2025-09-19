using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Abstractions;

namespace ECommerce.Business.Products.Commands.Update
{
    public class UpdateProductCommand : IBaseCommand<ProductResponseDto>
    {
        public int Id { get; set; }   // Güncellenecek ürün Id
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        //[JsonIgnore]
        //public int UserId { get; set; }

        public IReadOnlyList<string> CacheKeys => new[]
        {
            "all-products"
        };
    }
}