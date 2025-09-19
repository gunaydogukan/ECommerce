using ECommerce.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary Key
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasIndex(u => u.Email) // email unique
                   .IsUnique();

            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.PhoneNumber)
                   .HasMaxLength(20);

            // Relations
            builder.HasMany(u => u.Products)
                   .WithOne(p => p.User)
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Favorites)
                   .WithOne(f => f.User)
                   .HasForeignKey(f => f.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Orders)
                   .WithOne(o => o.User)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.UserRole)
                   .WithOne(ur => ur.User)
                   .HasForeignKey<UserRole>(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
