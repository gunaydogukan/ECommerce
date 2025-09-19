using ECommerce.Entities.Favorites;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Contexts
{
    public partial class AppDbContext
    {
        public DbSet<Favorite> Favorites => Set<Favorite>();
    }
}