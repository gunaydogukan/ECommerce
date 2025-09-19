using MediatR;
using ECommerce.Business.Favorites.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Favorites.Commands.Add
{
    public class AddFavroiteCommand : IBaseCommand<FavroiteResponseDto>, ICacheInvalidation
    {
        internal int UserId { get; set; }
        public int ProductId { get; set; }

        public IReadOnlyList<string> CacheKeys => new[]
        {
            $"favorites-user-{UserId}"
        };
    }
}