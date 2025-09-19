using ECommerce.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Contexts
{
    public partial class AppDbContext
    {
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    }
}