namespace ECommerce.Business.OrderItem.Dtos
{
    public record OrderItemCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
