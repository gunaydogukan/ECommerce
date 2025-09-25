using ECommerce.Business.Favorites.Dtos;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Favorites.Queries.GetMyFavorite
{
    public record GetMyFavoriteQuery : IUserSpecificCacheableQuery<IReadOnlyList<FavroiteResponseDto>>
    {
        //internal int UserId { get; set; }

        //public string CacheKey => $"favorites-user-{UserId}";

        //public TimeSpan? Expiration => TimeSpan.FromMinutes(10);
    }
}
