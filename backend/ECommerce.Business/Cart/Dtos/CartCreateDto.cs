namespace ECommerce.Business.Cart.Dtos;

public record CartCreateDto
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}