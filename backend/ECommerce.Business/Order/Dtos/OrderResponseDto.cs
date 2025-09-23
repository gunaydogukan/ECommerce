using ECommerce.Business.OrderItem.Dtos;

namespace ECommerce.Business.Order.Dtos
{
    public record OrderResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;
        public List<OrderItemResponseDto> OrderItems { get; set; } = new();
    }
}
