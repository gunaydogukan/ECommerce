using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Favorites.Commands.Delete
{
    public record DeleteFavoriteCommand(IReadOnlyList<int> ProductIds) : IBaseCommand<bool>, ICacheInvalidation
    {
        public IReadOnlyList<string> CacheKeys => new[]
        {
            "favorites-user-{UserId}"
        };
    }
}