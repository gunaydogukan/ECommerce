using ECommerce.Core.Abstractions;
using ECommerce.Core.Crud;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Concurrent;

namespace ECommerce.Core.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private readonly TContext _context;
        private IDbContextTransaction? _tx;
        private readonly ConcurrentDictionary<Type, object> _repositories;

        public UnitOfWork(TContext context)
        {
            _context = context;
            _repositories = new ConcurrentDictionary<Type, object>();
        }

        public ICrudDal<TEntity> Repository<TEntity>() where TEntity : class
        {
            return (ICrudDal<TEntity>)_repositories.GetOrAdd(typeof(ICrudDal<TEntity>), new BaseCrudDal<TEntity>(_context));
        }

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => _context.SaveChangesAsync(ct);

        public async Task BeginTransactionAsync(CancellationToken ct = default)
        {
            if (_tx is not null) return;
            _tx = await _context.Database.BeginTransactionAsync(ct);
        }

        public async Task CommitAsync(CancellationToken ct = default)
        {
            if (_tx is null) return;
            await _tx.CommitAsync(ct);
            await _tx.DisposeAsync();
            _tx = null;
        }

        public async Task RollbackAsync(CancellationToken ct = default)
        {
            if (_tx is null) return;
            await _tx.RollbackAsync(ct);
            await _tx.DisposeAsync();
            _tx = null;
        }

        public void Dispose() => _context.Dispose();
        public ValueTask DisposeAsync() => _context.DisposeAsync();
    }
}