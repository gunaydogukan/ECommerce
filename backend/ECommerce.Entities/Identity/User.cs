using ECommerce.Entities.Base;
using ECommerce.Entities.Catalog;
using ECommerce.Entities.Favorites;
using ECommerce.Entities.Orders;

namespace ECommerce.Entities.Identity
{
    public class User : AuditableEntity
    {
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        //Navigation 
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<Favorite>? Favorites { get; set; } = new List<Favorite>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public UserRole UserRole { get; set; } = null!;
    }
}
