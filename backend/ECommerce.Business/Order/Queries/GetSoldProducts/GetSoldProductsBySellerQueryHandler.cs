using ECommerce.Business.Order.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Order.Queries.GetSoldProducts
{
    public class GetSoldProductsBySellerQueryHandler
        : IRequestHandler<GetSoldProductsBySellerQuery, IReadOnlyList<SoldProductDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetSoldProductsBySellerQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IReadOnlyList<SoldProductDto>> Handle(
            GetSoldProductsBySellerQuery request,
            CancellationToken ct)
        {
            // Order repository al
            var orderRepo = _uow.Repository<Entities.Orders.Order>();

            // Query’yi kur
            var query = orderRepo.Query()
                .Include(o => o.User) // buyer
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product);

            var products = await query
                .SelectMany(o => o.OrderItems, (o, oi) => new { o, oi })
                .Where(x => x.oi.Product.UserId == request.SellerId)
                .Select(x => new SoldProductDto
                {
                    ProductId = x.oi.ProductId,
                    ProductName = x.oi.Product.Name,
                    Quantity = x.oi.Quantity,
                    TotalRevenue = x.oi.Quantity * x.oi.UnitPrice,
                    BuyerId = x.o.UserId,
                    BuyerEmail = x.o.User.Email
                })
                .ToListAsync(ct);

            if (products == null || products.Count == 0)
                throw new BusinessException("Satılan ürün bulunamadı.");

            return products;
        }
    }
}