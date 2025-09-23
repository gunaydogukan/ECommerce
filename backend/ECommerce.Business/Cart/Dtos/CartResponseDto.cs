namespace ECommerce.Business.Cart.Dtos;

public record CartResponseDto
{
    public int Id { get; set; }          
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal => UnitPrice * Quantity;
}