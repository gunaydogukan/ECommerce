using ECommerce.Business.Favorites.Dtos;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Favorites.Queries.GetMyFavorite
{
    public class GetMyFavoriteQuery : ICacheableQuery<IReadOnlyList<FavroiteResponseDto>>
    {
        internal int UserId { get; set; }

        // Kullanıcıya özel cache anahtarı
        public string CacheKey => $"favorites-user-{UserId}";

        public TimeSpan? Expiration => TimeSpan.FromMinutes(10);
    }
}
