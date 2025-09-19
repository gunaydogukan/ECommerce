using ECommerce.Entities.Favorites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations.Favorites
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(f => f.Id);

            // CreatedAt
            builder.Property(f => f.CreatedAt)
                .IsRequired();

            // Bir kullanıcı aynı ürünü 2 kere favoriye ekleyemesin uniq değer
            builder.HasIndex(f => new { f.UserId, f.ProductId })
                .IsUnique();

            // Relations
            builder.HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                //.IsRequired(false);

                builder.HasOne(f => f.Product)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(f => f.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
                //.IsRequired(false);
        }
    }
}