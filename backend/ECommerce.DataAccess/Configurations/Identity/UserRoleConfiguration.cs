using ECommerce.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations.Identity
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(ur => ur.Id);

            builder.HasIndex(ur => new { ur.UserId, ur.RoleId })
                .IsUnique();

            builder.HasOne(ur => ur.User)
                .WithOne(u => u.UserRole)
                .HasForeignKey<UserRole>(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                //.IsRequired(false);


            builder.HasOne(ur => ur.Role)
                .WithMany()
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
            //.IsRequired(false);
        }
    }
}