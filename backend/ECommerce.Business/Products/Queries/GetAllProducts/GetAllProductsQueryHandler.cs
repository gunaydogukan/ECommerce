using AutoMapper;
using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler
        : IRequestHandler<GetAllProductsQuery, IReadOnlyList<ProductResponseDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductResponseDto>> Handle(GetAllProductsQuery request, CancellationToken ct)
        {
            var productRepo = _uow.Repository<Product>();

            var products = await productRepo.Query()
                .AsNoTracking()
                .ToListAsync(ct);

            if (products == null || products.Count == 0)
                throw new BusinessException("Kayıtlı ürün bulunamadı.");

            return products.Select(ToResponseDto).ToList();
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