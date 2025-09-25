using AutoMapper;
using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Core.Helpers.Security;
using ECommerce.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Products.Queries.GetProductsByUserId
{
    public class GetMyProductsQueryHandler
        : IRequestHandler<GetMyProductsQuery, IReadOnlyList<ProductResponseDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public GetMyProductsQueryHandler(IUnitOfWork uow, IUserAccessor userAccessor, IMapper mapper)
        {
            _uow = uow;
            _userAccessor = userAccessor;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductResponseDto>> Handle(GetMyProductsQuery request, CancellationToken ct)
        {
            var userId = _userAccessor.GetUserId();
            //request.UserId = userId; 

            var productRepo = _uow.Repository<Product>();

            var products = await productRepo.Query()
                .AsNoTracking()
                .Where(p => p.UserId == userId)
                .ToListAsync(ct);

            if (products == null || products.Count == 0)
                throw new BusinessException("Kullanıcıya ait ürün bulunamadı.");

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