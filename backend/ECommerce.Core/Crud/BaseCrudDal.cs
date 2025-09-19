using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ECommerce.Entities.Base.Abstracts;

namespace ECommerce.Core.Crud
{
    public class BaseCrudDal<TEntity> : ICrudDal<TEntity> 
        where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseCrudDal(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(new object?[] { id }, ct);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(ct);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllWithAsync(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include,
            CancellationToken ct = default)
        {
            var query = include(_dbSet.AsQueryable());
            return await query.ToListAsync(ct);
        }

        public async Task<TEntity?> GetByIdWithAsync(
            int id,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include,
            CancellationToken ct = default)
        {
            var query = include(_dbSet.AsQueryable());
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id, ct);
        }

        public async Task<IReadOnlyList<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync(ct);
        }

        public IQueryable<TEntity> Query()
        {
            return _dbSet.AsQueryable();
        }

        public async Task AddAsync(TEntity entity, CancellationToken ct = default)
        {
            await _dbSet.AddAsync(entity, ct);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken ct = default)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        //hardDelete
        public Task DeleteAsync(TEntity entity, CancellationToken ct = default)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public Task SoftDeleteAsync(TEntity entity, CancellationToken ct = default)
        {
            if (entity is IAuditableEntity softDeleteEntity)
            {
                softDeleteEntity.IsDeleted = true;
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity);
            }
            return Task.CompletedTask;
        }
    }
}
