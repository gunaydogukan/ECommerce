using ECommerce.Entities.Base.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.DataAccess.Contexts
{
    public partial class AppDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IAuditableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "p");
                    var deletedCheck = Expression.Lambda(Expression.Equal(Expression.Property(parameter, "IsDeleted"), Expression.Constant(false)), parameter);
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(deletedCheck);
                }
            }
        }
    }
}