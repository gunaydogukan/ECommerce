using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ProductResponseDto?> Handle(GetProductByIdQuery request, CancellationToken ct)
        {
            var productRepo = _uow.Repository<Product>();

            var product = await productRepo.Query()
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == request.Id, ct);

            if (product == null)
                throw new BusinessException("Ürün bulunamadı.");

            return _mapper.Map<ProductResponseDto>(product);
        }
    }
}