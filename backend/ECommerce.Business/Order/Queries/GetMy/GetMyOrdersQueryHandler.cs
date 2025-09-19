using AutoMapper;
using ECommerce.Business.Order.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Core.Helpers.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Order.Queries.GetMy
{
    public class GetMyOrdersQueryHandler
        : IRequestHandler<GetMyOrdersQuery, IReadOnlyList<OrderResponseDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public GetMyOrdersQueryHandler(IUnitOfWork uow, IMapper mapper, IUserAccessor userAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<IReadOnlyList<OrderResponseDto>> Handle(GetMyOrdersQuery request, CancellationToken ct)
        {
            var orderRepo = _uow.Repository<Entities.Orders.Order>();
            var userId = _userAccessor.GetUserId();

            request.UserId = userId;

            var orders = await orderRepo.Query()
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == userId)
                .ToListAsync(ct);

            if (!orders.Any())
                throw new BusinessException("Kullanıcıya ait sipariş bulunamadı.");

            return _mapper.Map<IReadOnlyList<OrderResponseDto>>(orders);
        }
    }
}