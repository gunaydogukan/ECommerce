using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : ICacheableQuery<UserResponseDto>
    {
        public int Id { get; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public string CacheKey => $"user-{Id}";
        public TimeSpan? Expiration => TimeSpan.FromMinutes(30);
    }
}