using ECommerce.Core.Helpers.Security;
using ECommerce.Core.Interceptors;
using ECommerce.Core.Settings;
using ECommerce.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ECommerce.DataAccess.Contexts
{
    public partial class AppDbContext : DbContext
    {
        private readonly IUserAccessor _userAccessor;
        private readonly DbSettings _dbSettings;

        public AppDbContext(
            IUserAccessor userAccessor,
            IOptions<DbSettings> dbOptions
        )
        {
            _userAccessor = userAccessor;
            _dbSettings = dbOptions.Value; // IOptions’tan DbSettings çekiyoruz
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.AddInterceptors(
                    new LoggingSaveChangesInterceptor(),
                    new LoggingQueryInterceptor()
                );

                optionsBuilder.UseNpgsql(_dbSettings.Default);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedRoles();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override int SaveChanges()
        {
            ApplyAuditInfo();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInfo();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInfo()
        {
            var userId = _userAccessor.GetUserId();

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = userId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property(x => x.CreatedAt).IsModified = false;
                    entry.Property(x => x.CreatedBy).IsModified = false;

                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = userId;
                }
            }
        }

    }
}