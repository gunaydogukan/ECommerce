using AutoMapper;
using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Core.Helpers.Security;
using ECommerce.Entities.Catalog;
using MediatR;

namespace ECommerce.Business.Products.Commands.Update
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, ProductResponseDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public UpdateProductCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            IUserAccessor userAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<ProductResponseDto> Handle(UpdateProductCommand request, CancellationToken ct)
        {
            var productRepo = _uow.Repository<Product>();
            var userId = _userAccessor.GetUserId();

            var existing = await productRepo.GetByIdAsync(request.Id, ct);
            if (existing == null)
                throw new BusinessException("Ürün bulunamadı.");

            if (existing.UserId != userId)
                throw new BusinessException("Bu ürünü güncelleme yetkiniz yok.");

            _mapper.Map(request, existing);

            await productRepo.UpdateAsync(existing, ct);
            await _uow.SaveChangesAsync(ct);

            var loaded = await productRepo.GetByIdAsync(request.Id, ct);
            return _mapper.Map<ProductResponseDto>(loaded);
        }

    }
}
