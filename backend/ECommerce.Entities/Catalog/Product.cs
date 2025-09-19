using ECommerce.Entities.Base;
using ECommerce.Entities.Favorites;
using ECommerce.Entities.Identity;
using ECommerce.Entities.Orders;

namespace ECommerce.Entities.Catalog
{
    public class Product : AuditableEntity
    {
        public int CategoryId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!; // Ürünü ekleyen kullanıcı

        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }


        //Navigation
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public Category Category { get; set; } = null!;
        public IEnumerable<Favorite>? Favorites { get; set; } = new List<Favorite>();
    }
}
