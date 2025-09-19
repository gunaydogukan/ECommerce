using ECommerce.Core.Crud;

namespace ECommerce.Core.Abstractions
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);
        Task BeginTransactionAsync(CancellationToken ct = default);
        Task CommitAsync(CancellationToken ct = default);
        Task RollbackAsync(CancellationToken ct = default);

        ICrudDal<TEntity> Repository<TEntity>() where TEntity : class;
    }
}