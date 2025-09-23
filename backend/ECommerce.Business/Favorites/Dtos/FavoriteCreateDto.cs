namespace ECommerce.Business.Favorites.Dtos;

public record FavoriteCreateDto
{
    public int UserId { get; set; }
    public int ProductId { get; set; }

}