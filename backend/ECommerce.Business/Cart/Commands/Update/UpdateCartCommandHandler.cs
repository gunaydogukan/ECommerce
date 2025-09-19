using AutoMapper;
using ECommerce.Business.Cart.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Core.Helpers.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Cart.Commands.Update
{
    public class UpdateCartCommandHandler
        : IRequestHandler<UpdateCartCommand, CartResponseDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public UpdateCartCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            IUserAccessor userAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<CartResponseDto> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cartRepo = _uow.Repository<Entities.Orders.Cart>();
            var userId = _userAccessor.GetUserId();

            var existing = await cartRepo.GetByIdAsync(request.CartId, cancellationToken);
            if (existing == null)
                throw new BusinessException("Sepet öğesi bulunamadı.");

            if (existing.UserId != userId)
                throw new BusinessException("Bu sepet öğesini güncelleme yetkiniz yok.");

            _mapper.Map(request, existing);

            await cartRepo.UpdateAsync(existing, cancellationToken);
            //await _uow.SaveChangesAsync(cancellationToken);

            var updated = await cartRepo.GetByIdWithAsync(
                existing.Id,
                q => q.Include(c => c.Product),
                cancellationToken
            );

            return _mapper.Map<CartResponseDto>(updated!);
        }
    }
}
