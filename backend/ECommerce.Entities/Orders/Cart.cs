using ECommerce.Entities.Base;
using ECommerce.Entities.Catalog;
using ECommerce.Entities.Identity;

namespace ECommerce.Entities.Orders;

public class Cart : AuditableEntity
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    // Navigation
    public User User { get; set; } = null!;
    public Product Product { get; set; } = null!;
}