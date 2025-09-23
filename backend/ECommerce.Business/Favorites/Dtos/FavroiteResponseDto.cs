namespace ECommerce.Business.Favorites.Dtos;

public record FavroiteResponseDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
}