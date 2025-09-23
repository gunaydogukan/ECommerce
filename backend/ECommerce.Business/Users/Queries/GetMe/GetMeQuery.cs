using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Users.Queries.GetMe
{
    public record GetMeQuery : ICacheableQuery<UserResponseDto>
    {
        internal int UserId { get; set; }

        public string CacheKey => $"user-me-{UserId}";

        public TimeSpan? Expiration => TimeSpan.FromMinutes(15);
    }
}