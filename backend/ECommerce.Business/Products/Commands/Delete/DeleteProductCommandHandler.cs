using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Entities.Catalog;
using MediatR;

namespace ECommerce.Business.Products.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteProductCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken ct)
        {
            var productRepo = _uow.Repository<Product>();

            var existing = await productRepo.GetByIdAsync(request.Id, ct);
            if (existing == null)
                throw new BusinessException("Ürün bulunamadı.");

            await productRepo.SoftDeleteAsync(existing);
            //await _uow.SaveChangesAsync(ct);

            return true;
        }
    }
}