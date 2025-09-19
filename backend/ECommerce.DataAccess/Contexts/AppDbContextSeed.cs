using ECommerce.Entities.Catalog;
using ECommerce.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Contexts
{
    public static class AppDbContextSeed
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "User", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Role { Id = 2, Name = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Role { Id = 3, Name = "Moderator", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Elektronik"},
                new Category { Id = 2, Name = "Moda" },
                new Category { Id = 3, Name = "Ev & Yaşam" },
                new Category { Id = 4, Name = "Kitap" },
                new Category { Id = 5, Name = "Spor" }
            );
        }
    }
}