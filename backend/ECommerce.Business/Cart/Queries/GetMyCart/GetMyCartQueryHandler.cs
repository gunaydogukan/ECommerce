using AutoMapper;
using ECommerce.Business.Cart.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Cart.Queries.GetMyCart
{
    public class GetMyCartQueryHandler
        : IRequestHandler<GetMyCartQuery, IReadOnlyList<CartResponseDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public GetMyCartQueryHandler(IUnitOfWork uow, IMapper mapper, IUserAccessor userAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<IReadOnlyList<CartResponseDto>> Handle(
            GetMyCartQuery request,
            CancellationToken cancellationToken)
        {
            var cartRepo = _uow.Repository<Entities.Orders.Cart>();
            //request.UserId = _userAccessor.GetUserId();
            var userId = _userAccessor.GetUserId();

            var carts = await cartRepo.GetAllWithAsync(
                q => q.Where(c => c.UserId == userId)
                    .Include(c => c.Product)
                    .OrderBy(c => c.CreatedAt), 
                cancellationToken
            );

            if (carts == null || !carts.Any())
                throw new BusinessException("Sepet bulunamadı.");

            return _mapper.Map<IReadOnlyList<CartResponseDto>>(carts);
        }
    }
}