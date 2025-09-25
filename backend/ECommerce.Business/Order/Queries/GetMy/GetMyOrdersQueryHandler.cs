using ECommerce.Business.Order.Dtos;
using ECommerce.Business.OrderItem.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Order.Queries.GetMy
{
    public class GetMyOrdersQueryHandler
        : IRequestHandler<GetMyOrdersQuery, IReadOnlyList<OrderResponseDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserAccessor _userAccessor;

        public GetMyOrdersQueryHandler(
            IUnitOfWork uow, 
            IUserAccessor userAccessor)
        {
            _uow = uow;
            _userAccessor = userAccessor;
        }

        public async Task<IReadOnlyList<OrderResponseDto>> Handle(GetMyOrdersQuery request, CancellationToken ct)
        {
            var orderRepo = _uow.Repository<Entities.Orders.Order>();
            var userId = _userAccessor.GetUserId();

            //request.UserId = userId;

            var orders = await orderRepo.Query()
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == userId)
                .ToListAsync(ct);

            if (!orders.Any())
                throw new BusinessException("Kullanıcıya ait sipariş bulunamadı.");

            return orders.Select(ToOrderResponseDto).ToList();
        }

        private static OrderResponseDto ToOrderResponseDto(Entities.Orders.Order order)
        {
            return new OrderResponseDto
            {
                Id = order.Id,
                UserId = order.UserId,
                Status = order.Status,
                TotalAmount = order.TotalAmount,
                OrderItems = order.OrderItems?.Select(ToOrderItemResponseDto).ToList() ?? new List<OrderItemResponseDto>()
            };
        }

        private static OrderItemResponseDto ToOrderItemResponseDto(Entities.Orders.OrderItem item)
        {
            return new OrderItemResponseDto
            {
                ProductId = item.ProductId,
                ProductName = item.Product?.Name ?? string.Empty,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            };
        }

    }
}