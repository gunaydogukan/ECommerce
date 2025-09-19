using ECommerce.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Contexts
{
    public partial class AppDbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    }
}