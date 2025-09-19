using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Core.Helpers.Security;
using MediatR;

namespace ECommerce.Business.Favorites.Commands.Delete
{
    public class DeleteFavoriteCommandHandler : IRequestHandler<DeleteFavoriteCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserAccessor _userAccessor;

        public DeleteFavoriteCommandHandler(
            IUnitOfWork uow,
            IUserAccessor userAccessor)
        {
            _uow = uow;
            _userAccessor = userAccessor;
        }

        public async Task<bool> Handle(DeleteFavoriteCommand request, CancellationToken ct)
        {
            var favoriteRepo = _uow.Repository<ECommerce.Entities.Favorites.Favorite>();
            var userId = _userAccessor.GetUserId();

            var favorites = await favoriteRepo.WhereAsync(
                f => f.UserId == userId && request.ProductIds.Contains(f.ProductId), ct);

            if (favorites == null || favorites.Count == 0)
                throw new BusinessException("Silinecek favori bulunamadı.");

            foreach (var favorite in favorites)
            {
                await favoriteRepo.DeleteAsync(favorite, ct);
            }

            //await _uow.SaveChangesAsync(ct);
            return true;
        }
    }
}