namespace ECommerce.Business.Products.Dtos
{
    public record ProductCreateDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }   
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}