using ECommerce.Entities.Catalog;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Contexts
{
    public partial class AppDbContext
    {
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
    }
}