//using AutoMapper;
using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Entities.Catalog;
using MediatR;

namespace ECommerce.Business.Products.Commands.Update
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, ProductResponseDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserAccessor _userAccessor;

        public UpdateProductCommandHandler(
            IUnitOfWork uow,
            IUserAccessor userAccessor)
        {
            _uow = uow;
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

            existing.CategoryId = request.CategoryId ?? existing.CategoryId;
            existing.Name = request.Name ?? existing.Name;
            existing.Description = request.Description ?? existing.Description;
            existing.Price = request.Price ?? existing.Price;

            await productRepo.UpdateAsync(existing, ct);

            var loaded = await productRepo.GetByIdAsync(request.Id, ct);

            var res = new ProductResponseDto
            {
                Id = loaded.Id,
                Name = loaded.Name,
                Description = loaded.Description,
                Price = loaded.Price,
                CategoryId = loaded.CategoryId,
                UserId = loaded.UserId
            };

            return res;
        }

    }
}
