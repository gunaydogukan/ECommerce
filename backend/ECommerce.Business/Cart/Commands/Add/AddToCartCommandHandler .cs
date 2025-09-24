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
        //private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public AddToCartCommandHandler(
            IUnitOfWork uow,
            //IMapper mapper,
            IUserAccessor userAccessor)
        {
            _uow = uow;
            //_mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<CartResponseDto> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var cartRepo = _uow.Repository<Entities.Orders.Cart>();

            var userId = _userAccessor.GetUserId();

            request.UserId = userId;
            var dto = new CartCreateDto
            {
                UserId = userId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };

            var existing = await cartRepo.Query()
                .Include(c=>c.Product)
                .FirstOrDefaultAsync(c => c.UserId == dto.UserId && c.ProductId == dto.ProductId, cancellationToken);

            if (existing != null)
            {
                existing.Quantity += dto.Quantity;
                await cartRepo.UpdateAsync(existing, cancellationToken);
                return ToResponseDto(existing);
            }

            var entity = new Entities.Orders.Cart
            {
                UserId = userId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };
            
            await cartRepo.AddAsync(entity, cancellationToken);

            var loaded = await cartRepo.GetByIdWithAsync(
                entity.Id,
                q => q.Include(c => c.Product),
                cancellationToken
            );

            return ToResponseDto(loaded ?? entity);
        }

        private static CartResponseDto ToResponseDto(Entities.Orders.Cart cart)
        {
            return new CartResponseDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                ProductId = cart.ProductId,
                ProductName = cart.Product?.Name ?? string.Empty,
                UnitPrice = cart.Product?.Price ?? 0,
                Quantity = cart.Quantity
            };
        }
    }
}