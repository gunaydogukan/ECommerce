using AutoMapper;
using ECommerce.Business.Products.Dtos;
using ECommerce.Core.Abstractions;
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

            var entity = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId
            };

            entity.UserId = _userAccessor.GetUserId();

            await productRepo.AddAsync(entity, ct);

            var res = new ProductResponseDto
            {
                Id = entity.Id,
                CategoryId = entity.CategoryId,
                UserId = entity.UserId,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price
            };

            return res;
        }
    }
}