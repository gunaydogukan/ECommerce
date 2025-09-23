using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(int Id) : ICacheableQuery<UserResponseDto>
    {
        public string CacheKey => $"user-{Id}";
        public TimeSpan? Expiration => TimeSpan.FromMinutes(30);
    }
}