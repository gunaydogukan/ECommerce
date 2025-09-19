using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Core.Helpers.Security;
using MediatR;

namespace ECommerce.Business.Cart.Commands.Delete
{
    public class DeleteFromCartCommandHandler
        : IRequestHandler<DeleteFromCartCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserAccessor _userAccessor;

        public DeleteFromCartCommandHandler(IUnitOfWork uow, IUserAccessor userAccessor)
        {
            _uow = uow;
            _userAccessor = userAccessor;
        }

        public async Task<bool> Handle(DeleteFromCartCommand request, CancellationToken cancellationToken)
        {
            var cartRepo = _uow.Repository<Entities.Orders.Cart>();
            var userId = _userAccessor.GetUserId();

            var existing = await cartRepo.GetByIdAsync(request.CartId, cancellationToken);

            if (existing == null)
                throw new BusinessException("Sepet öğesi bulunamadı.");

            if (existing.UserId != userId)
                throw new BusinessException("Bu sepet öğesini silme yetkiniz yok.");

            await cartRepo.DeleteAsync(existing, cancellationToken);
            //await _uow.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}