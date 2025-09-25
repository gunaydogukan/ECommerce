//using AutoMapper;
using ECommerce.Business.Favorites.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Helpers.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Favorites.Queries.GetMyFavorite
{
    public class GetMyFavoriteQueryHandler
        : IRequestHandler<GetMyFavoriteQuery, IReadOnlyList<FavroiteResponseDto>>
    {
        private readonly IUnitOfWork _uow;
        //private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public GetMyFavoriteQueryHandler(
            IUnitOfWork uow,
            //IMapper mapper,
            IUserAccessor userAccessor)
        {
            _uow = uow;
            //_mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<IReadOnlyList<FavroiteResponseDto>> Handle(
            GetMyFavoriteQuery request,
            CancellationToken cancellationToken)
        {
            var favoriteRepo = _uow.Repository<ECommerce.Entities.Favorites.Favorite>();
            var userId = _userAccessor.GetUserId();
            //request.UserId = userId; 

            var favorites = await favoriteRepo.GetAllWithAsync(
                query => query.Where(f => f.UserId == userId)
                    .Include(f => f.Product),
                cancellationToken
            );

            return favorites
                .Select(ToResponseDto)
                .ToList()
                .AsReadOnly();
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