using ECommerce.Entities.Base;
using ECommerce.Entities.Catalog;
using ECommerce.Entities.Identity;

namespace ECommerce.Entities.Favorites
{
    public class Favorite : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //Navigation
        public User User { get; set; } = null!; // Fav ekleyen kullanıcı
        public Product Product { get; set; } = null!;

    }
}
