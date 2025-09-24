using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler
        : IRequestHandler<GetProductByIdQuery, ProductResponseDto?>
    {
        private readonly IUnitOfWork _uow;

        public GetProductByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ProductResponseDto?> Handle(GetProductByIdQuery request, CancellationToken ct)
        {
            var productRepo = _uow.Repository<Product>();

            var product = await productRepo.Query()
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == request.Id, ct);

            if (product == null)
                throw new BusinessException("Ürün bulunamadı.");

            return ToResponseDto(product);
        }

        private static ProductResponseDto ToResponseDto(Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                UserId = product.UserId
            };
        }

    }


}