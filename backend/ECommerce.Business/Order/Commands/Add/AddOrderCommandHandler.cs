//using AutoMapper;
using ECommerce.Business.Order.Dtos;
using ECommerce.Business.OrderItem.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Order.Commands.Add
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, OrderResponseDto>
    {
        private readonly IUnitOfWork _uow;
        //private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public AddOrderCommandHandler(
            IUnitOfWork uow,
            //IMapper mapper,
            IUserAccessor userAccessor)
        {
            _uow = uow;
            //_mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<OrderResponseDto> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var userId = _userAccessor.GetUserId();
            var items = request.Items;
            

            if (items == null || !items.Any())
            {
                var cartRepo = _uow.Repository<Entities.Orders.Cart>();

                var cartItems = await cartRepo.Query()
                    .Where(c => c.UserId == userId)
                    .Include(c => c.Product)
                    .ToListAsync(cancellationToken);

                if (!cartItems.Any())
                    throw new BusinessException("Sepet boş, sipariş oluşturulamadı.");

                items = cartItems.Select(c => new OrderItemCreateDto
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity
                }).ToList();

                foreach (var ci in cartItems)
                    await cartRepo.DeleteAsync(ci);
            }

            // orderItem olusturma 
            var orderItems = new List<Entities.Orders.OrderItem>();
            decimal totalAmount = 0;

            foreach (var item in items)
            {
                var product = await _uow.Repository<Entities.Catalog.Product>()
                    .Query()
                    .FirstOrDefaultAsync(p => p.Id == item.ProductId, cancellationToken);

                if (product == null)
                    throw new Exception($"Ürün bulunamadı: {item.ProductId}");

                if (product.UserId == userId)
                    throw new BusinessException("Kendi ürününüze sipariş veremezsiniz.");


                var orderItem = new Entities.Orders.OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };

                orderItems.Add(orderItem);
                totalAmount += orderItem.Quantity * orderItem.UnitPrice;
            }

            var order = new Entities.Orders.Order
            {
                UserId = userId,
                Status = "Pending",
                TotalAmount = totalAmount,
                OrderItems = orderItems
            };

            await _uow.Repository<Entities.Orders.Order>().AddAsync(order, cancellationToken);
            //await _uow.SaveChangesAsync(cancellationToken);

            var loaded = await _uow.Repository<Entities.Orders.Order>()
                .Query()
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == order.Id, cancellationToken);

            return ToResponseDto(loaded ?? order);
        }

        private static OrderResponseDto ToResponseDto(Entities.Orders.Order order)
        {
            return new OrderResponseDto
            {
                Id = order.Id,
                UserId = order.UserId,
                Status = order.Status,
                TotalAmount = order.TotalAmount,
                OrderItems = order.OrderItems?.Select(ToItemResponseDto).ToList() ?? new List<OrderItemResponseDto>()
            };
        }

        private static OrderItemResponseDto ToItemResponseDto(Entities.Orders.OrderItem item)
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
