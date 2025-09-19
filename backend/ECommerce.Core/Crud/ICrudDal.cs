using System.Linq.Expressions;

namespace ECommerce.Core.Crud
{
    public interface ICrudDal<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct = default);
        Task<TEntity?> GetByIdWithAsync(int id, Func<IQueryable<TEntity>, IQueryable<TEntity>> include, CancellationToken ct = default);
        Task<IReadOnlyList<TEntity>> GetAllWithAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> include, CancellationToken ct = default);
        Task<IReadOnlyList<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
        Task AddAsync(TEntity entity, CancellationToken ct = default);
        Task UpdateAsync(TEntity entity, CancellationToken ct = default);
        Task DeleteAsync(TEntity entity, CancellationToken ct = default);
        Task SoftDeleteAsync(TEntity entity, CancellationToken ct = default);

        IQueryable<TEntity> Query();
    }
}

