using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Users.Commands.Delete
{
    public record DeleteUserCommand(int Id) : IBaseCommand<bool>, ICacheInvalidation
    {
        public IReadOnlyList<string> CacheKeys => new[]
        {
            "all-users",
            $"user-{Id}",
            $"user-me-{Id}"
        };
    }
}