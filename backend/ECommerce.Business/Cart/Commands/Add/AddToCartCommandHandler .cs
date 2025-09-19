using AutoMapper;
using ECommerce.Business.Cart.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Helpers.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Cart.Commands.Add
{
    public class AddToCartCommandHandler
        : IRequestHandler<AddToCartCommand, CartResponseDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public AddToCartCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            IUserAccessor userAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<CartResponseDto> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var cartRepo = _uow.Repository<Entities.Orders.Cart>();

            var userId = _userAccessor.GetUserId();

            request.UserId = userId;
            var dto = _mapper.Map<CartCreateDto>(request);

            var existing = await cartRepo.Query()
                .FirstOrDefaultAsync(c => c.UserId == dto.UserId && c.ProductId == dto.ProductId, cancellationToken);

            if (existing != null)
            {
                existing.Quantity += dto.Quantity;
                await cartRepo.UpdateAsync(existing, cancellationToken);
                return _mapper.Map<CartResponseDto>(existing);
            }

            var entity = _mapper.Map<Entities.Orders.Cart>(dto);
            await cartRepo.AddAsync(entity, cancellationToken);

            var added = _mapper.Map<CartResponseDto>(entity);
            //await _uow.SaveChangesAsync(cancellationToken);

            var loaded = await cartRepo.GetByIdWithAsync(
                added.Id,
                q => q.Include(c => c.Product),
                cancellationToken
            );

            return _mapper.Map<CartResponseDto>(loaded) ?? added;
        }
    }
}