using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Users.Queries.GetMe
{
    public class GetMeQuery : ICacheableQuery<UserResponseDto>
    {
        internal int UserId { get; set; }

        public string CacheKey => $"user-me-{UserId}";

        public TimeSpan? Expiration => TimeSpan.FromMinutes(15);
    }
}