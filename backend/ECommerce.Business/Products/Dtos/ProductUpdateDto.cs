namespace ECommerce.Business.Products.Dtos
{
    public class ProductUpdateDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}