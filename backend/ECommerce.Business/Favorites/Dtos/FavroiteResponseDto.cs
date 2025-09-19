namespace ECommerce.Business.Favorites.Dtos;

public class FavroiteResponseDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
}