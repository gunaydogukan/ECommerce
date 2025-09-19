using ECommerce.Business.OrderItem.Dtos;

namespace ECommerce.Business.Order.Dtos;

public class OrderCreateDto
{
    public int UserId { get; set; }
    public List<OrderItemCreateDto> Items { get; set; } = new();
}