//using AutoMapper;
using ECommerce.Business.Favorites.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Favorites.Commands.Add
{
    public class AddFavoriteCommandHandler
        : IRequestHandler<AddFavroiteCommand, FavroiteResponseDto>
    {
        private readonly IUnitOfWork _uow;
        //private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public AddFavoriteCommandHandler(
            IUnitOfWork uow,
            //IMapper mapper,
            IUserAccessor userAccessor)
        {
            _uow = uow;
            //_mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<FavroiteResponseDto> Handle(AddFavroiteCommand request, CancellationToken ct)
        {
            var favoriteRepo = _uow.Repository<ECommerce.Entities.Favorites.Favorite>();
            var userId = _userAccessor.GetUserId();

            var exists = await favoriteRepo.Query()
                .AnyAsync(f => f.UserId == userId && f.ProductId == request.ProductId, ct);

            if (exists)
                throw new BusinessException("Bu ürün zaten favorilerde.");

            var entity = new ECommerce.Entities.Favorites.Favorite
            {
                UserId = userId,
                ProductId = request.ProductId
            };

            await favoriteRepo.AddAsync(entity, ct);

            var loaded = await favoriteRepo.GetByIdWithAsync(
                entity.Id,
                q => q.Include(f => f.Product),
                ct
            );

            return ToResponseDto(loaded ?? entity);
        }
        private static FavroiteResponseDto ToResponseDto(ECommerce.Entities.Favorites.Favorite fav)
        {
            return new FavroiteResponseDto
            {
                Id = fav.Id,
                ProductId = fav.ProductId,
                ProductName = fav.Product?.Name ?? string.Empty,
                Price = fav.Product?.Price ?? 0
            };
        }
    }
}