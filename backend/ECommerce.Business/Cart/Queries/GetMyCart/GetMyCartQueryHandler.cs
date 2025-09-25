using ECommerce.Business.Cart.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Cart.Queries.GetMyCart
{
    public class GetMyCartQueryHandler
        : IRequestHandler<GetMyCartQuery, IReadOnlyList<CartResponseDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserAccessor _userAccessor;

        public GetMyCartQueryHandler(IUnitOfWork uow, IUserAccessor userAccessor)
        {
            _uow = uow;
            _userAccessor = userAccessor;
        }

        public async Task<IReadOnlyList<CartResponseDto>> Handle(
            GetMyCartQuery request,
            CancellationToken cancellationToken)
        {
            var cartRepo = _uow.Repository<Entities.Orders.Cart>();
            var userId = _userAccessor.GetUserId();

            var carts = await cartRepo.GetAllWithAsync(
                q => q.Where(c => c.UserId == userId)
                    .Include(c => c.Product)
                    .OrderBy(c => c.CreatedAt), 
                cancellationToken
            );

            if (carts == null || !carts.Any())
                throw new BusinessException("Sepet bulunamadı.");

            var dtoList = carts.Select(c => new CartResponseDto
            {
                Id = c.Id,
                UserId = c.UserId,
                ProductId = c.ProductId,
                ProductName = c.Product?.Name ?? string.Empty,
                UnitPrice = c.Product?.Price ?? 0,
                Quantity = c.Quantity
            }).ToList();

            return dtoList;
        }
    }
}