using AutoMapper;
using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Entities.Catalog;
using MediatR;

namespace ECommerce.Business.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryHandler
        : IRequestHandler<GetProductsByCategoryQuery, IReadOnlyList<ProductResponseDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetProductsByCategoryQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductResponseDto>> Handle(
            GetProductsByCategoryQuery request, CancellationToken ct)
        {
            var repo = _uow.Repository<Product>();

            var products = await repo.WhereAsync(p => p.CategoryId == request.CategoryId, ct);

            return _mapper.Map<IReadOnlyList<ProductResponseDto>>(products);
        }
    }
}