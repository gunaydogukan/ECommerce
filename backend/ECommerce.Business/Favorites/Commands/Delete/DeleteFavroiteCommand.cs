using ECommerce.Business.Favorites.Queries.GetMyFavorite;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Favorites.Commands.Delete
{
    public record DeleteFavoriteCommand(IReadOnlyList<int> ProductIds) : IBaseCommand<bool>, ICacheInvalidation
    {
        public IReadOnlyList<Type> QueryTypes => new[]
        {
            typeof(GetMyFavoriteQuery)
        };
    }
}