using AutoMapper;
using ECommerce.Business.Favorites.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Helpers.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Favorites.Commands.Add
{
    public class AddFavoriteCommandHandler
        : IRequestHandler<AddFavroiteCommand, FavroiteResponseDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public AddFavoriteCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            IUserAccessor userAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<FavroiteResponseDto> Handle(AddFavroiteCommand request, CancellationToken ct)
        {
            var favoriteRepo = _uow.Repository<ECommerce.Entities.Favorites.Favorite>();

            var userId = _userAccessor.GetUserId();

            request.UserId = userId;
            var dto = _mapper.Map<FavoriteCreateDto>(request);

            var entity = _mapper.Map<ECommerce.Entities.Favorites.Favorite>(dto);

            await favoriteRepo.AddAsync(entity, ct);
            //await _uow.SaveChangesAsync(ct);

            var loaded = await favoriteRepo.GetByIdWithAsync(
                entity.Id,
                q => q.Include(f => f.Product),
                ct
            );

            return _mapper.Map<FavroiteResponseDto>(loaded ?? entity);
        }

    }
}