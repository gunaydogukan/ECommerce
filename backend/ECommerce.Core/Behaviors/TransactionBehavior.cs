using ECommerce.Core.Abstractions;
using MediatR;

namespace ECommerce.Core.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand<TResponse>
    {
        private readonly IUnitOfWork _uow;

        public TransactionBehavior(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken ct)
        {
            await _uow.BeginTransactionAsync(ct);

            try
            {
                var response = await next();

                await _uow.SaveChangesAsync(ct);
                await _uow.CommitAsync(ct);

                return response;
            }
            catch
            {
                await _uow.RollbackAsync(ct);
                throw;
            }
        }
    }
}