using ECommerce.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations.Identity
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(rp => rp.Id);

            builder.HasIndex(rp => new { rp.RoleId, rp.PermissionId })
                .IsUnique();

            builder.HasOne(rp => rp.Role)
                .WithMany()
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
                //.IsRequired(false);


                builder.HasOne(rp => rp.Permission)
                    .WithMany()
                    .HasForeignKey(rp => rp.PermissionId)
                    .OnDelete(DeleteBehavior.Cascade);
                //.IsRequired(false);
        }
    }
}