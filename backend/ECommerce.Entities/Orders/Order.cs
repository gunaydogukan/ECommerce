using ECommerce.Entities.Base;
using ECommerce.Entities.Identity;

namespace ECommerce.Entities.Orders
{
    public class Order : AuditableEntity
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";

        // Navigaton
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public User User { get; set; } = null!;
    }
}