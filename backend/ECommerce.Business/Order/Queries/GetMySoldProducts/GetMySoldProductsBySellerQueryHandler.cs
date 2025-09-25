using ECommerce.Business.Order.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Order.Queries.GetSoldProducts
{
    public class GetMySoldProductsBySellerQueryHandler
        : IRequestHandler<GetMySoldProductsBySellerQuery, IReadOnlyList<SoldProductDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserAccessor _userAccessor;

        public GetMySoldProductsBySellerQueryHandler(IUnitOfWork uow, IUserAccessor userAccessor)
        {
            _uow = uow;
            _userAccessor = userAccessor;
        }

        public async Task<IReadOnlyList<SoldProductDto>> Handle(
            GetMySoldProductsBySellerQuery request,
            CancellationToken ct)
        {
            //request.SellerId = _userAccessor.GetUserId();
            var sellerId = _userAccessor.GetUserId();
            
            var orderRepo = _uow.Repository<Entities.Orders.Order>();

            var sales = await orderRepo.Query()
                .Include(o => o.User) 
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .Where(o => o.OrderItems.Any(oi => oi.Product.UserId == sellerId))
                .SelectMany(o => o.OrderItems.Select(oi => new
                {
                    o.Id,
                    BuyerId = o.UserId,
                    BuyerEmail = o.User.Email,
                    oi.ProductId,
                    ProductName = oi.Product.Name,
                    oi.Quantity,
                    oi.UnitPrice
                }))
                .ToListAsync(ct);

            if (sales == null || sales.Count == 0)
                throw new BusinessException("Satılan ürün bulunamadı.");

            var grouped = sales
                .GroupBy(s => new { s.ProductId, s.ProductName })
                .Select(g => new SoldProductDto
                {
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.ProductName,
                    TotalQuantity = g.Sum(x => x.Quantity),
                    TotalRevenue = g.Sum(x => x.Quantity * x.UnitPrice),
                    Sales = g.Select(x => new SoldProductSaleDto
                    {
                        OrderId = x.Id,
                        BuyerId = x.BuyerId,
                        BuyerEmail = x.BuyerEmail,
                        Quantity = x.Quantity,
                        UnitPrice = x.UnitPrice,
                        Subtotal = x.Quantity * x.UnitPrice
                    }).ToList()
                })
                .ToList();

            return grouped;
        }
    }
}
