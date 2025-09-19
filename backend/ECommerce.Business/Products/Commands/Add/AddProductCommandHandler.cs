using AutoMapper;
using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Helpers.Security;
using ECommerce.Entities.Catalog;
using MediatR;

namespace ECommerce.Business.Products.Commands.Add
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductResponseDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public AddProductCommandHandler(IUnitOfWork uow, IMapper mapper, IUserAccessor userAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<ProductResponseDto> Handle(AddProductCommand request, CancellationToken ct)
        {
            var productRepo = _uow.Repository<Product>();

            var entity = _mapper.Map<Product>(request);
            entity.UserId = _userAccessor.GetUserId();

            await productRepo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);

            return _mapper.Map<ProductResponseDto>(entity);
        }
    }
}