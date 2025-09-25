using ECommerce.Business.Favorites.Dtos;
using ECommerce.Business.Favorites.Queries.GetMyFavorite;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Favorites.Commands.Add
{
    public record AddFavroiteCommand : IBaseCommand<FavroiteResponseDto>, ICacheInvalidation
    {
        public int ProductId { get; set; }

        public IReadOnlyList<Type> QueryTypes => new[]
        {
            typeof(GetMyFavoriteQuery)
        };
    }
}