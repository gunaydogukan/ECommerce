using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Favorites.Commands.Delete
{
    public class DeleteFavoriteCommand : IBaseCommand<bool>, ICacheInvalidation
    {
        //public int UserId { get; }
        public IReadOnlyList<int> ProductIds { get; }

        public DeleteFavoriteCommand(IEnumerable<int> productIds)
        {
            //UserId = userId;
            ProductIds = productIds.ToList();
        }

        public IReadOnlyList<string> CacheKeys => new[]
        {
            $"favorites-user-{{UserId}}"
        };
    }
}