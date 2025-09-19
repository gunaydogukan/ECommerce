using ECommerce.Entities.Base;
using ECommerce.Entities.Catalog;

namespace ECommerce.Entities.Orders
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;

        //Navigation
        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}